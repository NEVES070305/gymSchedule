# gymSchedule

# Escopo do Projeto

- Linguagem de Programação: Utilizaremos C# para o desenvolvimento do backend.
- Arquitetura de Dados: Adotaremos o padrão Repository com procedures no banco de dados, com ênfase em SQL Server.
- Segurança: Implementaremos autenticação e autorização por meio de token JWT.
- Framework: Inicialmente, faremos uso do Entity Framework para facilitar a interação com o banco de dados. 
- Ferramentas de Desenvolvimento: Faremos uso de ferramentas como Draw.io e Figma para auxiliar no design e na representação visual do sistema.

# Descrição

Esta aplicação ASP.NET oferece uma API RESTful para cadastro e gerenciamento de academias. A API permite aos usuários criar, ler, atualizar e excluir academias, além de adicionar informações adicionais, como endereço, horários de funcionamento e modalidades oferecidas.

# Funcionalidades

Cadastro de academias: Crie novas academias com informações básicas, como nome, CNPJ e endereço.
Gerenciamento de academias: Leia, atualize e exclua academias cadastradas.
API RESTful: Utilize métodos HTTP padrão (GET, POST, PUT, DELETE) para interagir com a API.
Autenticação: Implemente autenticação para proteger o acesso à API.

# Requisitos

- .NET Framework 4.6.1 ou superior
- Visual Studio 2017 ou superior
- Banco de dados SQL Server (ou outro banco de dados compatível)
- Instalação

Clone o repositório: git clone https://github.com/NEVES070305/gymSchedule.git
Abra a solução no Visual Studio.
Configure a conexão com o banco de dados no arquivo app.config.
Execute o projeto.

# Uso da API

A API pode ser acessada através de ferramentas como Postman ou diretamente pelo código. A documentação da API está disponível no arquivo Swagger.json.

Observações

Este projeto ainda está em desenvolvimento e novas funcionalidades serão adicionadas no futuro.
A documentação da API pode ser atualizada com o tempo.
Se você tiver dúvidas ou precisar de ajuda, não hesite em entrar em contato.

# Detalhes Adicionais

Segurança: A API ainda não implementa autenticação e autorização. É recomendável implementar essas medidas de segurança antes de implantar a API em produção.
Validação de dados: A API não realiza validação completa dos dados de entrada. É recomendável implementar validação de dados para garantir a integridade dos dados.
Gerenciamento de erros: A API não implementa um sistema completo de gerenciamento de erros. É recomendável implementar um sistema de gerenciamento de erros para fornecer mensagens de erro informativas aos usuários.
Monitoramento: É recomendável monitorar a API em produção para identificar e corrigir problemas rapidamente.

# Ferramentas Adicionais

- Swagger: A ferramenta Swagger pode ser utilizada para gerar documentação interativa da API.
- Postman: O Postman é uma ferramenta para testar e depurar APIs.
- Visual Studio Code: O Visual Studio Code é um

3. **Arquitetura do Sistema**
   
    - Um padrão de design amplamente utilizado no desenvolvimento de software, especialmente em aplicações web. Ela divide uma aplicação em três componentes principais: Model, View e Controller.
    - O Model representa a camada de dados da aplicação. A View é responsável pela apresentação dos dados ao usuário. O Controller atua como um intermediário entre o Model e a View.
    - Uso do padrão Repository para acesso a dados.
      
5. **Requisitos Funcionais**
   
    - Cadastro de academias, redes de academia, pessoas e funcionarios, isso até o momento.
    - Checking em márquinas(posterior)
    - Via esquema em draw.io
      
7. **Requisitos Não Funcionais**
   
    - Segurança e autenticação via JWT
      
9. **Tecnologias Utilizadas**
    
    - Linguagens de programação (C#)
    - Frameworks (Entity Framework)
    - Bancos de dados (SQL Server)
    - Ferramentas de desenvolvimento (Draw.io, Figma)

   


