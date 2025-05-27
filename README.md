# Taller

# Melhoria feitas: 
| Problema no Código Legado        | Solução na Minimal API                     |
| -------------------------------- | ------------------------------------------ |
| **SQL Injection**                | LINQ + EF Core = consultas parametrizadas  |
| **Sem validação de entrada**     | `if (string.IsNullOrWhiteSpace(username))` |
| **Sem tratamento de erros**      | `try-catch` e `Results.Problem()`          |
| **XSS via saída não sanitizada** | JSON automático com `Results.Ok()`         |
| **Código confuso**               | Clareza e concisão com Minimal APIs        |

Stack: C#, ASP.NET Core, SQL Server, Entity Framework (for data access)





