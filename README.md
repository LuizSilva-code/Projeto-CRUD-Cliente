# Projeto-CRUD-Cliente
📝 Descrição
Esta é uma API RESTful desenvolvida em ASP.NET Core 8 para gerenciar um cadastro completo de clientes. A aplicação permite realizar operações de CRUD (Criar, Ler, Atualizar e Excluir/Inativar) para clientes, seus endereços e cartões de crédito.

O projeto foi estruturado seguindo princípios de arquitetura limpa, separando as responsabilidades em camadas de Domínio, Aplicação, e Infraestrutura.

✨ Funcionalidades
Clientes:

Cadastrar novos clientes com validação de CPF e senha forte.

Listar todos os clientes cadastrados com informações de contato.

Editar informações cadastrais de um cliente.

Inativar o cadastro de um cliente.

Alterar a senha de um cliente.

Endereços:

Cadastrar múltiplos endereços para um cliente (Cobrança e Entrega).

Editar os endereços de um cliente.

Listar todos os endereços de um cliente específico.

Cartões de Crédito:

Cadastrar um ou mais cartões de crédito para um cliente.

Listar os cartões de um cliente específico.

Validações e Regras de Negócio:

Validação de CPF (formato e dígitos verificadores).

Validação de existência de cliente com o mesmo CPF.

Exigência de senha forte (mínimo de 8 caracteres, com letras maiúsculas, minúsculas e caracteres especiais).

Criptografia de senhas utilizando BCrypt.

Atribuição de um número de ranking para clientes ativos.

Obrigatoriedade de cadastrar ao menos um endereço de cobrança e um de entrega.

🚀 Tecnologias Utilizadas
ASP.NET Core 8: Framework para construção da API.

Entity Framework Core 9: ORM para interação com o banco de dados.

SQLite: Banco de dados relacional leve utilizado no projeto.

AutoMapper: Biblioteca para mapeamento de objetos entre camadas (DTOs e Entidades).

Swagger (Swashbuckle): Ferramenta para documentação e teste interativo da API.

BCrypt.Net-Next: Para hashing e verificação de senhas.

⚙️ Configuração e Instalação
Siga os passos abaixo para executar o projeto localmente.

Pré-requisitos
.NET 8 SDK

Um editor de código de sua preferência (Visual Studio, VS Code, etc.).

Passos
Clone o repositório:

Bash

git clone https://seurepositorio/CrudCliente.git
cd CrudCliente
Restaure as dependências:
Abra o projeto no seu editor ou execute o comando abaixo no terminal:

Bash

dotnet restore
Execute a Aplicação:

Bash

dotnet run
A aplicação iniciará e aplicará as migrations automaticamente, criando o banco de dados crudCliente.db na raiz do projeto.

Acesse a documentação da API:
Com a aplicação em execução, acesse a URL do Swagger no seu navegador para visualizar e testar os endpoints:

http://localhost:5052/swagger (para o perfil http)

https://localhost:7123/swagger (para o perfil httpss)

(As portas podem variar, verifique o arquivo Properties/launchSettings.json)

Endpoints da API
A API expõe os seguintes endpoints principais:

Cliente
POST /Cadastrar/Cliente: Cadastra um novo cliente.

GET /Listar/Clientes: Lista todos os clientes.

GET /Listar/Enderecos/{clienteId}: Lista os endereços de um cliente.

GET /Listar/Cartoes/{clienteId}: Lista os cartões de um cliente.

PUT /Editar/Cliente/{id}: Edita os dados de um cliente.

PUT /Inativar/Cliente/{id}: Inativa o cadastro de um cliente.

PUT /AlterarSenha/Cliente/{id}: Altera a senha de um cliente.

POST /CadastrarCartao/Cliente/{id}: Cadastra um novo cartão para o cliente.

Endereço
POST /CadastrarEndereco/{id}: Cadastra um novo endereço para o cliente.

PUT /EditarEndereco/{id}: Edita um endereço existente.
