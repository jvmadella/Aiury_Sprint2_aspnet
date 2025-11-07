using Aiury.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAjudanteRepository, AjudanteRepository>();
builder.Services.AddSingleton<ICidadeRepository, CidadeRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Rotas convencionais e personalizadas (default para Home/Index, custom para Ajudantes/Cidades via attributes)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// -------- Minimal API Search + HATEOAS --------
app.MapGet("/api/ajudantes/search", (
    IAjudanteRepository repo,
    int page = 1,
    int pageSize = 10,
    string? sortBy = "id",
    string? sortDir = "asc",
    string? q = null,
    HttpContext http = null!
) =>
{
    var items = repo.Query();
    if (!string.IsNullOrWhiteSpace(q))
        items = items.Where(x => (x.NomeReal ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase) || (x.AreaAtuacao ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase));

    bool asc = (sortDir ?? "asc").Equals("asc", StringComparison.OrdinalIgnoreCase);
    items = (sortBy ?? "id").ToLowerInvariant() switch
    {
        "nome" => asc ? items.OrderBy(x => x.NomeReal) : items.OrderByDescending(x => x.NomeReal),
        "area" => asc ? items.OrderBy(x => x.AreaAtuacao) : items.OrderByDescending(x => x.AreaAtuacao),
        _ => asc ? items.OrderBy(x => x.IdAjudante) : items.OrderByDescending(x => x.IdAjudante)
    };

    var total = items.Count();
    var data = items.Skip((page-1)*pageSize).Take(pageSize).ToList();
    string url(int p) => $"{http.Request.Scheme}://{http.Request.Host}/api/ajudantes/search?page={p}&pageSize={pageSize}&sortBy={sortBy}&sortDir={sortDir}&q={q}";

    var result = new
    {
        page,
        pageSize,
        total,
        _links = new Dictionary<string, string?>
        {
            ["self"] = url(page),
            ["first"] = url(1),
            ["prev"] = page>1 ? url(page-1) : null,
            ["next"] = (page*pageSize) < total ? url(page+1) : null,
            ["last"] = url((int)Math.Ceiling(total/(double)pageSize))
        },
        items = data.Select(d => new {
            d.IdAjudante, d.NomeReal, d.AreaAtuacao,
            _links = new Dictionary<string, string>
            {
                ["html"] = $"{http.Request.Scheme}://{http.Request.Host}/ajudantes/detalhes/{d.IdAjudante}"
            }
        })
    };
    return Results.Ok(result);
});

app.MapGet("/api/cidades/search", (
    ICidadeRepository repo,
    int page = 1,
    int pageSize = 10,
    string? sortBy = "id",
    string? sortDir = "asc",
    string? q = null,
    HttpContext http = null!
) =>
{
    var items = repo.Query();
    if (!string.IsNullOrWhiteSpace(q))
        items = items.Where(x => (x.NomeCidade ?? string.Empty).Contains(q, StringComparison.OrdinalIgnoreCase));

    bool asc = (sortDir ?? "asc").Equals("asc", StringComparison.OrdinalIgnoreCase);
    items = (sortBy ?? "id").ToLowerInvariant() switch
    {
        "nome" => asc ? items.OrderBy(x => x.NomeCidade) : items.OrderByDescending(x => x.NomeCidade),
        _ => asc ? items.OrderBy(x => x.IdCidade) : items.OrderByDescending(x => x.IdCidade)
    };

    var total = items.Count();
    var data = items.Skip((page-1)*pageSize).Take(pageSize).ToList();
    string url(int p) => $"{http.Request.Scheme}://{http.Request.Host}/api/cidades/search?page={p}&pageSize={pageSize}&sortBy={sortBy}&sortDir={sortDir}&q={q}";

    var result = new
    {
        page,
        pageSize,
        total,
        _links = new Dictionary<string, string?>
        {
            ["self"] = url(page),
            ["first"] = url(1),
            ["prev"] = page>1 ? url(page-1) : null,
            ["next"] = (page*pageSize) < total ? url(page+1) : null,
            ["last"] = url((int)Math.Ceiling(total/(double)pageSize))
        },
        items = data.Select(d => new {
            d.IdCidade, d.NomeCidade,
            _links = new Dictionary<string, string>
            {
                ["html"] = $"{http.Request.Scheme}://{http.Request.Host}/cidades/detalhes/{d.IdCidade}"
            }
        })
    };
    return Results.Ok(result);
});

app.Run();
