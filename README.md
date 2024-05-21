# gymSchedule

# Escopo do Projeto

Ao elaborar a documentação do escopo de um projeto fullstack de TI, é importante ter em mente que a complexidade do projeto e as necessidades da equipe podem exigir a inclusão de outros tópicos ou detalhes. Nesse sentido, considerando as especificidades do projeto:

- Linguagem de Programação: Utilizaremos C# para o desenvolvimento do backend.
- Arquitetura de Dados: Adotaremos o padrão Repository com procedures no banco de dados, com ênfase em SQL Server.
- Segurança: Implementaremos autenticação e autorização por meio de token JWT.
- Framework: Inicialmente, faremos uso do Entity Framework para facilitar a interação com o banco de dados. No frontend, consideraremos o React com TypeScript, sendo o Next.js o framework inicial para o desenvolvimento.
- Ferramentas de Desenvolvimento: Faremos uso de ferramentas como Draw.io e Figma para auxiliar no design e na representação visual do sistema.
- Outras Considerações: Levaremos em conta a possibilidade de conexão sem frameworks adicionais, além de garantir a escalabilidade e a manutenibilidade do sistema.

1. **Introdução**
    - Ser possível ao final do projeto visualizar os equipamentos disponíveis a serem reservados.
    - Cadastro de redes de academia, academia e funcionários
    - Facilitação do treino
2. **Visão Geral do Sistema**
    - Cliente/alunos de academias
    - Requisitos Funcionais:
       **Cadastro de Usuários:**
        - Os usuários devem poder se cadastrar no sistema fornecendo informações como nome, e-mail e senha.
        - Deve existir validação dos campos de entrada para garantir a integridade dos dados.
    
       **Autenticação de Usuários:**
        - Os usuários registrados devem poder fazer login no sistema utilizando suas credenciais.
        - O sistema deve verificar as credenciais do usuário e autenticá-lo com sucesso.
    
       **Gerenciamento de Produtos:**
        - Os usuários com permissões adequadas devem poder adicionar, editar e excluir produtos do sistema.
        - Deve haver a possibilidade de associar categorias e outras informações relevantes a cada produto.
    
        Requisitos Não Funcionais:
    
        **Desempenho:**
          - O sistema deve ser capaz de lidar com um grande número de solicitações simultâneas sem degradar significativamente o desempenho.
          - O tempo de resposta para as operações principais do sistema (como login e consulta de produtos) deve ser mínimo.
      
        **Segurança:**
        - A autenticação de usuários deve ser segura, utilizando token JWT para proteger as comunicações entre cliente e servidor.
        - As senhas dos usuários devem ser armazenadas de forma segura, utilizando técnicas de hashing e salting.
    
        **Escalabilidade:**
          - O sistema deve ser projetado para escalabilidade, de modo que possa lidar com um aumento no número de usuários e de dados sem comprometer o desempenho.
          - Deve ser possível adicionar novos servidores conforme necessário para lidar com a carga crescente.

3. **Arquitetura do Sistema**
    - Explicação da arquitetura MVC (Model-View-Controller)
    - Papel de cada componente (Model, View, Controller)
    - Uso do padrão Repository para acesso a dados
4. **Requisitos Funcionais**
    - Lista detalhada de funcionalidades do sistema
    - Casos de uso principais
    - Fluxos de trabalho do usuário
5. **Requisitos Não Funcionais**
    - Desempenho esperado do sistema
    - Segurança e autenticação
    - Escalabilidade e manutenibilidade
6. **Tecnologias Utilizadas**
    - Linguagens de programação (C#)
    - Frameworks (Entity Framework, Next.js)
    - Bancos de dados (SQL Server)
    - Ferramentas de desenvolvimento (Draw.io, Figma)
7. **Modelo de Dados**
    - Banco de dados relacional(SqlServer) e NoSql
    - Relacionamentos entre entidades
    - Esquema de armazenamento
8. **Interfaces do Usuário**
    - Layout e design das interfaces
    - Funcionalidades específicas de cada tela
    - Fluxos de interação do usuário
9. **Arquitetura de Implementação**
    - Organização do código-fonte
    - Divisão em módulos e componentes
    - Dependências entre os componentes
10. **Planejamento de Implantação `(Vitor Maia)`**
    - Ambientes de implantação (dev, teste, produção)
    - Procedimentos de implantação
    - Migração de dados, se necessário
11. **Gestão de Configuração e Controle de Versão**
    - Políticas de controle de versão
    - Ramificação do código-fonte
    - Uso de ferramentas de controle de versão (ex: Git)
12. **Gestão de Projetos**
    - Cronograma de desenvolvimento
    - Atribuição de tarefas e responsabilidades
    - Monitoramento do progresso do projeto
13. **Considerações de Segurança `(Carlos)`**
    - Mecanismos de autenticação e autorização
    - Proteção contra vulnerabilidades conhecidas
    - Auditoria e registro de atividades sensíveis
14. **Considerações de Manutenção**
    - Planos de suporte pós-implantação
    - Processo de correção de bugs e implementação de melhorias
    - Atualizações de segurança e de software

Dependendo da complexidade do projeto e das necessidades específicas da equipe, outros tópicos ou detalhes podem ser adicionados conforme necessário.
