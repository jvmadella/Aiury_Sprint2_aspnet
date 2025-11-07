# Aiury — Plataforma Digital de Apoio Psicossocial e Intervenção em Crise

## 1. Contexto do Problema (resumo)
O Brasil enfrenta um cenário crítico relacionado à saúde mental e à segurança social, caracterizado pela falta de acesso a atendimentos especializados, ausência de sistemas digitais unificados de apoio em crises emocionais e baixa integração entre os serviços públicos de saúde, proteção e acolhimento. O estigma relacionado ao sofrimento psicológico e a dificuldade de localizar ajuda confiável agravam o quadro, especialmente entre populações em vulnerabilidade social.

## 2. Objetivo da Solução (resumo)
A plataforma **Aiury** tem como finalidade funcionar como primeiro ponto de apoio digital para indivíduos em sofrimento emocional ou risco psicossocial. A solução busca:
- Oferecer acesso rápido a conteúdos de acolhimento e regulação emocional.
- Conectar usuários a redes de apoio (psicológica, social ou jurídica).
- Integrar serviços de saúde mental, assistência pública e geolocalização.
- Garantir anonimato, acessibilidade e redução de barreiras de busca por ajuda.

---

## 3. Tecnologias Utilizadas
| Tecnologia | Aplicação |
|------------|-----------|
| **ASP.NET Core 8 MVC** | Camada web da aplicação (telas, controllers, rotas) |
| **C#** | Linguagem principal |
| **Minimal API** | Implementação da API REST com paginação e HATEOAS |
| **Bootstrap 5** | Layout responsivo |
| **Rider / Visual Studio** | IDEs de desenvolvimento |
| **Repositórios In-Memory** | Persistência temporária sem banco de dados |
| **DataAnnotations** | Validações nas ViewModels |

---

## 4. Arquitetura da Aplicação
A aplicação segue o padrão **MVC + Web API**, composta por:

```
/Models           → Classes de domínio (Ajudantes, Cidades, Estados, Chat etc.)
/ViewModels       → Representação de entrada/saída com validação
/Controllers      → Lógica de navegação e ações CRUD (Ajudantes, Cidades, Home)
/Services         → Repositórios em memória (IAjudanteRepository, ICidadeRepository)
/Views            → Telas Razor (Index, Create, Edit, Delete, Details)
/api/...          → Minimal API configurada com filtros, ordenação e paginação
Program.cs        → Configuração de DI, rotas, endpoints e serviços
```

---

## 5. Sprint 1 — Entregas
| Entrega | Descrição |
|---------|-----------|
| Estrutura inicial ASP.NET MVC | Projeto criado com controller base, layout e rota padrão |
| Modelos iniciais | Ajudantes, Cidades, Estados, Chat |
| Views básicas | Home (Index, Privacy) |
| Controle de autenticação | Iniciada estrutura de acesso |

---

## 6. Sprint 2 — Evoluções Implementadas
| Requisito | Implementação |
|-----------|--------------|
| Rotas personalizadas | `/ajudantes`, `/cidades`, com parâmetros e slug |
| Layout completo com Bootstrap | Navbar + rodapé + navegação dinâmica |
| CRUD com validação | Ajudantes e Cidades com ViewModels validados |
| Tag Helpers | Utilizados em formulários, links e validação |
| Minimal API | `/api/ajudantes/search` e `/api/cidades/search` |
| Filtros de busca | `?q=` para pesquisa textual |
| Paginação e ordenação | `?page=`, `?pageSize=`, `?sortBy=`, `?sortDir=` |
| HATEOAS ativo | Links de navegação no JSON: self, first, prev, next, last |
| Repositório em memória | Persistência sem banco, com DI configurada |

---

## 7. Autores
| Nome | RM |
|--------|------|
| João Victor Madella | 561007 |
| Nathália Mantovani de Falco | 99904 |
| Renato de Angelo | 560585 |

