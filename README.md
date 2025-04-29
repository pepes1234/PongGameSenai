# PongGameSenai

![.NET 6.0](https://img.shields.io/badge/.NET-6.0-blue) ![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-green) ![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-yellow) ![Kinect SDK](https://img.shields.io/badge/Kinect-SDK-lightblue) ![C#](https://img.shields.io/badge/Language-C%23-blueviolet) ![MIT License](https://img.shields.io/badge/License-MIT-lightgrey)

> Jogo Pong controlado pelo sensor Kinect com backend em ASP.NET Core para gestão de usuários e placares via reconhecimento facial e rastreamento de mãos.

>O projeto foi uma proposta de atividade do curso Senai Celso Charuri, a ideia principal era conseguir fazer um "kinect" com a webcam do computador, qual leria nossos movimentos e jogariamos um jogo dessa forma. Infelizmente o projeto não teve fim, porém ainda tem códigos muito interessantes

>A proposta era fazer um Pong Game, para ser 1 jogador vs 1 jogador, para isso utilizariamos trackings das mãos dos jogadores, a qual seria previamente registrado. Também teria registro e reconhecimento facial para analise de resultados e login no jogo, que seria feito com algoritimos de K-Means utilizando a paleta de cores especifica da pessoa, o que trás diversos problemas como diferença de iluminação, porém foi a forma mais facil encontrada.

---

## 📚 Sumário

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Pré-requisitos](#pré-requisitos)
- [Estrutura do Repositório](#estrutura-do-repositório)
- [Backend](#backend)
  - [Configuração do Banco](#configuração-do-banco)
  - [Executar API](#executar-api)
  - [Endpoints](#endpoints)
- [Frontend](#frontend)
  - [Hand Tracking & Blur](#hand-tracking--blur)
  - [Reconhecimento Facial](#reconhecimento-facial)
  - [Interface Pong](#interface-pong)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

---

## 💡 Sobre o Projeto

O **PongGameSenai** integra:

1. **Backend**: API RESTful em **ASP.NET Core 6.0** com **Entity Framework Core** para persistir usuários, dados faciais e placares.
2. **Reconhecimento Facial**: módulo console que usa **KMeans** para verificação de face via array de cores.
3. **Hand Tracking & Blur**: aplicação que usa **Kinect SDK** para detectar a mão e aplicar blur no fundo.
4. **Interface Pong**: jogo Pong em **WinForms**, onde as raquetes são controladas pelo movimento das mãos e resultados enviados ao backend.

Use este projeto para aprender sobre integração de sensores, visão computacional e aplicações full-stack .NET.

---

## 🚀 Tecnologias

| Componente               | Tecnologia                         |
|--------------------------|------------------------------------|
| Backend API              | ASP.NET Core 6.0, EF Core          |
| Banco de Dados           | SQL Server                         |
| Serviços (Reconhecimento)| C# Console (KMeans)                |
| Hand Tracking & Blur     | Kinect SDK, WinForms               |
| Interface Pong           | WinForms (.NET 6.0), C#            |

---

## ✅ Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (local ou remoto)
- [Kinect SDK](https://www.microsoft.com/en-us/download/details.aspx?id=44561)
- Visual Studio 2022 ou superior (para projetos WinForms)

---

## 🗂️ Estrutura do Repositório

```plain
PongGameSenai/
├── backend/                  # API ASP.NET Core (.NET 6.0)
│   ├── Controllers/          # UserController.cs
│   ├── Model/                # EF Core DbContext e entidades
│   ├── Services/             # UserService (KMeans)
│   ├── script.sql            # Cria DB e tabelas
│   ├── createmodel.ps1       # Scaffold modelos do DB
│   ├── appsettings.json      # ConnectionStrings
│   └── Program.cs            # Configuração e Swagger
├── frontend/                 # Soluções Kinect + Pong
│   ├── Hand/                 # Hand Tracking & Blur (WinForms)
│   ├── Recognition/          # Console KMeans Face Verify
│   └── Interface/            # Jogo Pong WinForms
├── .vscode/
├── LICENSE
└── README.md
```

---

## Backend

### ⚙️ Configuração do Banco

Execute `backend/script.sql` no SQL Server para criar a base **PongGameDB** e tabelas `Usuario`, `Score` e `RGB`.

```sql
USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PongGameDB')
  DROP DATABASE PongGameDB;
GO
CREATE DATABASE PongGameDB;
GO
USE PongGameDB;
GO
-- Criação de tabelas...
```

Ajuste a _connection string_ em `backend/appsettings.json` se necessário.

### ▶️ Executar API

```bash
cd backend
dotnet build
dotnet run
```

A API ficará em `https://localhost:5001` e `http://localhost:5000`. Acesse Swagger em `/swagger`.

### 📡 Endpoints

| Método | Rota                   | Descrição                                           |
|--------|------------------------|-----------------------------------------------------|
| GET    | `/User`                | Registra usuário e dados faciais (query params)     |
| GET    | `/User/login/{id}`     | Verifica face e retorna status de login             |

---

## Frontend

### 🖐️ Hand Tracking & Blur

Projeto WinForms que:

- Conecta ao Kinect para detectar posição da mão.
- Aplica blur no restante da cena.

```bash
cd frontend/Hand
# Abra HandTracking.sln no VS e execute.
```

### 🧠 Reconhecimento Facial

App console que:

- Recebe array de cores de uma imagem.
- Compara com dados armazenados via algoritmo KMeans.

```bash
cd frontend/Recognition
dotnet build
dotnet run
```

### 🖥️ Interface Pong

Formulário WinForms onde:

- As raquetes são movimentadas pelo tracking da mão.
- O placar é enviado à API ao final de cada partida.

1. Abra `frontend/Interface/PongGameSenai.sln` no Visual Studio.
2. Compile e execute.

---
