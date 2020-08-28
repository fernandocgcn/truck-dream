# Truck Dream

Um CRUD de Caminhões implementado em C# (.NET Core) e Angular (TypeScript, JavaScript), através de Web APIs RESTful modernas e autônomas, com troca de informações em formato JSON.

![](/misc/ClassDiagram.png)

![](/misc/ComponentDiagram.png)

## Tecnologias Utilizadas

### Banco de Dados (SQLite - Lib: Microsoft.EntityFrameworkCore.Sqlite)

* Utilizei um banco de dados simples e leve para demonstrar como a aplicação adapta-se a qualquer tipo de database relacional, modificando apenas a biblioteca de acesso ao banco. A simplicidade e rapidez na implantação de um DB local nesse caso são mais relevantes para a demonstração do projeto.

### Back-End (C# - .NET Core)

* src/TruckDream.Domain - Biblioteca do domínio e modelo de dados do projeto (entidades). Acesso aos dados com Entity Framework Core, utilizando Migrations e Seed para criar o DB, e os padrões de projeto Repository e Unit of Work (Microsoft.EntityFrameworkCore.DbContext).  

* src/TruckDream.Tests - Testes de unidade (MSTest) dos services e controllers (domínio e lógica do negócio). Fundamental para a utilização de TDD no desenvolvimento do projeto, ajudando a manter um baixo acoplamento e a detectar critérios dos requisitos ainda não considerados.  

### Front-End (C# - .NET Core, TypeScript/JavaScript - Angular)

* src/TruckDream.Web - Web API RESTful contendo os controllers e Aplicação SPA (Angular) contendo a view, utilizando os padrões MVC e Injeção de Dependência para Inversão de Controle dos serviços utilizados.  

### Metodologias, Técnicas e Princípios Utilizados

* SOLID, Design Patterns, DDD, TDD, OOP, ER Model, KISS, DRY

## Screenshots da Aplicação

![](/misc/screenshots/01.png)
![](/misc/screenshots/02.png)
![](/misc/screenshots/03.png)
![](/misc/screenshots/04.png)
![](/misc/screenshots/05.png)

## Tutorial de Instalação no Windows para Desenvolvedores

### Pre-requisitos

[Instalar o SDK do .NET Core 3.1 mais recente](https://dotnet.microsoft.com/download/dotnet-core/3.1) no computador que irá gerar o pacote de instalação da aplicação no servidor, ou seja, onde está o código-fonte do projeto.  

Para verificar se o computador já possui o .NET Core 3.1 instalado, na janela do terminal (prompt de comando), execute o comando a seguir:

```
dotnet --version
```

[Instalar o Node Package Manager mais recente](https://www.npmjs.com/get-npm) também nesse mesmo computador que irá gerar o pacote de instalação da aplicação no servidor.  

Para verificar se o computador já possui o NPM instalado, na janela do terminal (prompt de comando), execute o comando a seguir:

```
npm --version
```

No servidor onde irá hospedar a aplicação:  

1. Habilitar o IIS:  
No Windows, navegue até Painel de Controle > Programas > Programas e Recursos > Ativar ou desativar recursos do Windows (lado esquerdo da tela).  
Selecione a caixa de seleção Serviços de Informações da Internet. Selecione OK.  

2. [Instalar o Windows Hosting Bundle do ASP.NET Core Runtime 3.1 mais recente](https://dotnet.microsoft.com/download/dotnet-core/3.1).

### Publicação

Com o SDK devidamente instalado, vá para a pasta onde estão os projetos da aplicação (truck-dream\src), para compilar a aplicação, ler as dependências especificadas nos arquivos dos projetos, e publicar o conjunto de arquivos resultante em um diretório (<OUTPUT_DIRECTORY>), execute o comando a seguir:

```
dotnet publish –o <OUTPUT_DIRECTORY>
```

Depois de gerado (esse passo pode levar alguns minutos devido às dependências do Angular/NPM), copie o diretório <OUTPUT_DIRECTORY> para o servidor.

### Configuração do IIS

1. Primeiro criar um Pool de Aplicativos para os sites em ASP.NET Core, para isto abra o IIS, vá em Pools de Aplicativos e clique em "Adicionar Pool de Aplicativos..."  

2. Defina o nome, e selecione "Sem Código Gerenciado" para a Versão do .NET CLR, isto porque o Hosting Bundle que instalamos irá fazer o gerenciamento da aplicação e clique em OK.  

3. Para criar a aplicação basta clicar com o botão direito em Default Web Site e depois em "Adicionar Aplicativo...".

4. Defina o Alias (nome da aplicação), selecione o Pool de Aplicativos criado anteriormente e a pasta onde está o conjunto de arquivos resultante da publicação no Caminho físico.  

Pronto, você já pode acessar a API!

## Autor

* **Fernando Cordeiro Gondim Cavalcante Neto** - [fernandocgcn@GitHub](https://github.com/fernandocgcn) e [fernandocgcn@LinkedIn](https://www.linkedin.com/in/fernandocgcn)
