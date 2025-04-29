# ProjetoEstacionamento

![.NET 6.0](https://img.shields.io/badge/.NET-6.0-blue) ![C#](https://img.shields.io/badge/Language-C%23-blueviolet) ![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-yellow) ![Swagger](https://img.shields.io/badge/Swagger-API%20Docs-brightgreen) ![MIT License](https://img.shields.io/badge/License-MIT-lightgrey)

> API RESTful em ASP.NET Core para gerenciar alocações de veículos em concessionárias.

---

## 📚 Sumário

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Geração de Models](#geração-de-models)
- [Uso / Execução](#uso--execução)
- [Endpoints da API](#endpoints-da-api)
- [Modelos de Dados](#modelos-de-dados)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuindo](#contribuindo)
- [Licença](#licença)
- [Autor](#autor)

---

## 💡 Sobre o Projeto

O **ProjetoEstacionamento** é uma API simples que:

- Verifica se há vaga disponível em uma área de concessionária (`Alocacao`).
- Consulta detalhes de um veículo por nome de modelo (`Automovei`).
- Mantém registros de clientes e concessionárias.

Use este boilerplate para aprender a criar APIs com ASP.NET Core, Entity Framework Core e Swagger.

---

## 🚀 Tecnologias

| Camada                | Tecnologia                  |
|-----------------------|-----------------------------|
| Framework             | ASP.NET Core 6.0            |
| ORM                   | Entity Framework Core 7.0   |
| Banco de Dados        | SQL Server                  |
| API Docs              | Swagger / Swashbuckle       |
| Linguagem             | C# 10                       |
| Scripting             | PowerShell (createmodel.ps1)|

---

## ✅ Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (instância local ou remota)
- PowerShell 5.1+

---

## 🛠️ Instalação

```bash
# 1. Clone o repositório
git clone https://github.com/pepes1234/ProjetoEstacionamento.git
cd ProjetoEstacionamento

# 2. (Opcional) Abra no Visual Studio ou VS Code
code .
```

---

## ⚙️ Configuração

### String de conexão

O contexto `SistemaFabricaAutomotivaContext` contém uma _connection string_ default:

```csharp
=> optionsBuilder.UseSqlServer(
   "Data Source=SNCCHLAB02F13\\SQLEXPRESS;"
 + "Initial Catalog=SistemaFabricaAutomotiva;"
 + "Integrated Security=SSPI;TrustServerCertificate=True");
```

Altere-a diretamente em `Model/SistemaFabricaAutomotivaContext.cs` ou use _scaffolding_ para gerar um novo contexto:

```powershell
# No PowerShell, forneça servidor e database:
.\\createmodel.ps1 \
  MyServerName \
  MyDatabaseName
```

Isso criará/atualizará a pasta `Model/` com as entidades mapeadas.

---

## 🧱 Geração de Models

O script PowerShell `createmodel.ps1` utiliza o EF Core para scaffold:

```powershell
.\createmodel.ps1 \
  <ServerName> \
  <DatabaseName>
```

Ele instalará as ferramentas necessárias e executará:

```powershell
dotnet ef dbcontext scaffold \
  "Data Source=<ServerName>;Initial Catalog=<DatabaseName>;Integrated Security=SSPI;TrustServerCertificate=True" \
  Microsoft.EntityFrameworkCore.SqlServer --force -o Model
```

---

## ▶️ Uso / Execução

```bash
cd ProjetoEstacionamento
# Build e run da API
dotnet build
dotnet run
```

A API estará disponível em:

- `https://localhost:5001`
- `http://localhost:5000`

Acesse a documentação interativa em `/swagger` (ex.: `https://localhost:5001/swagger`).

---

## 📡 Endpoints da API

| Método | Rota                                 | Descrição                                     |
|--------|--------------------------------------|-----------------------------------------------|
| GET    | `/concessionaria/{areaNumber}`       | Verifica se há alocação na área (`bool`).     |
| GET    | `/concessionaria/consultCar/{model}` | Retorna dados do veículo pelo nome do modelo. |

**Exemplos:**

- Verificar área 10:
  ```bash
  curl https://localhost:5001/concessionaria/10
  ```
- Consultar carro "Civic":
  ```bash
  curl https://localhost:5001/concessionaria/consultCar/Civic
  ```

---

## 🗃️ Modelos de Dados

- **Alocacao**: `Id`, `Area`, `Automoveis`, `Concessionaria`, `Quantidade`  
- **Automovei**: `Id`, `Modelo`, `Preco`  
- **Cliente**: `Id`, `Nome`  
- **Concessionaria**: `Id`, `Nome`  

---

## 🗂️ Estrutura do Projeto

```
ProjetoEstacionamento/
├── Controllers/
│   └── ConcessionariaController.cs
├── Model/
│   ├── Alocacao.cs
│   ├── Automovei.cs
│   ├── Cliente.cs
│   ├── Concessionaria.cs
│   └── SistemaFabricaAutomotivaContext.cs
├── createmodel.ps1
├── appsettings.json
├── Program.cs
├── ProjetoEstacionamento.csproj
└── README.md  (este arquivo)
```

---

## 🤝 Contribuindo

1. Faça um **fork** deste repositório  
2. Crie uma nova branch: `git checkout -b feature/minha-feature`  
3. Commit suas mudanças: `git commit -m "feat: descrição da feature"`  
4. Push para seu fork: `git push origin feature/minha-feature`  
5. Abra um **Pull Request**

---

## 📄 Licença

Este projeto está licenciado sob a **MIT License**. Veja [LICENSE](LICENSE) para detalhes.

---

## 👤 Autor

Feito com ❤️ por [@pepes1234](https://github.com/pepes1234)

