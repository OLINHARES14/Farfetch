# Farfetch - Processo Seletivo
Projeto de 'Toggler Service' da Farfetch

   Foi implementado uma api com a funcionalidade do 'Toggler Service' chamada '/api/order/register' ela possui um 
tipo de 'Toggle' cadastrado, no qual possui a configuração dos serviços que podem gerar um 'register', poderíamos 
aplicar o conceito do 'Toggle' de diversas outras formas, mas no desafio proposto esse foi o cenário contemplado no 
código realizado aqui versionado.
   Temos 3 cadastros básicos em apis implementados, que são 'Toggle', 'ServiceRota' e 'ServiceRotaToggle' eles são 
utilizados como base na implementação do 'Toggler Service'.
   Não foi possível cobrir todos cenários para Testes e Validação, pois o objetivo foi focar na implementação do fluxo 
de ponta a ponta.
   Para resolver o problema de configuração possível em diversos servidores, foi implementado o controle do acesso 
no banco de dados,  tendo assim um único ponto de configuração a ser feito.

#  Sobre o desenvolvimento do sistema
- .Net Core
- Banco de Dados LocalDb
- Object oriented programming
- SOLID Principles
- DDD
- Rest API
- Testes
- Migration in Code First
- Injeção de dependência
- Filter Authorization  (Utilizado para implementar o 'Toggle')
- Filter Authetication (Utilizado para gerar o protocolo de requisição)
- Filter Request (Utilizado para manter alguns valores no Header do Request)
- Base de Dados
	
# Primeiros passos
1- Começaremos gerando o banco de dados e para isso utilizaremos a técnica migrations.
	A- Utilizar o console para podermos aplicar os comandos 
	Abrir - Console do Gerenciador de Pacotes

	B- Necessário selecionar o projeto abaixo para executar os comandos do migration
	Selecionar - 4.Infra\Farfetch.Infra

	C- Gerar os scripts
	Add-Migration "Nome que desejar"

	D- Executar scripts no banco de dados
	Update-Database
	
2- Executar o projeto
	Será aplicado um script de carga no banco de dados de forma automática para que seja representado o ambiente proposto no desafio 'ToggleService'.

3- Utilizar ferramenta para executar APIs, uma indicação é usar o 'Postman'

4- Procurar na documentação abaixo a API de rota '/api/order/register' e executar passando o Header com 'Authorization' referente a 'ServiceRota' que deseja fazer o 'register'.
   A- No primeiro momento a API de rota '/api/order/register', está configurada para o toggle Description: 'IsButtonTrue' e Flag: '1' (true), que está configurado para ser utilizado para qualquer chamada de 'Authorization' referente a 'ServiceRota'.
   B- Experimente alterar por API de Update o 'Toggle' da 'ServiceRotaToggle' para o toggle Description: 'IsButtonTrue' e Flag: '0' (false) 
   C- Fazendo um novo chamado a API de rota '/api/order/register' com o 'Authorization' da 'ServiceRota' da rota igual '/api/service/a' NÃO SERÁ mais possível realizar um novo 'register' na tabela.
  D- Fazendo um novo chamado a API de rota '/api/order/register' com o 'Authorization' da 'ServiceRota' da rota igual '/api/service/abc' SERÁ possível realizar um novo 'register' na tabela.
  E- Pode realizar a consulta a API ' /api/order/register' com o verbo 'GET' para consultar todos os 'register' já incluídos.

5- Agora será apenas decidir qual será as rotas permitidas por 'Toggle' e configurar a mesma no 'ServiceRotaToggle'.

Boa sorte.

# Validações
- Requests com validações
- Dados de busca com validações

# Testes Unitários
- Construção de alguns cenários válidos e inválidos

# Testes Integração
- Construção do cenário de order

# Base de dados
- Base de dados consta as seguintes tabelas:
     - Toggle (Cadastramento dos flags)
     - ServiceRota (Cadastramento das rotas que utilizam as apis com 'Toggle')
     - ToggleServiceRota (Relacionamento de permissão das 'ServiceRota' por 'Toggle')
       Obs. Se um Toggle não tiver relacionamento algum na tabela 'ToggleServiceRota' isso quer dizer que a rota associado a esse 'Toggle' deixará livre o acesso a qualquer rota que desejar utilizar o serviço.
     - ServiceRotaToggle (Cadastramento das rotas que utilizam o 'Toggle')
     - Order (Registro de quais serviços conseguiram passar pela 'ServiceRotaToggle')
- Criado um seed para alimentar a base com os dados referente ao desafio

# Chamada API
- APIs desenvolvidas: 
	Toggle
	(Post) Create / (Get) GetAll / (Get) Get / (Post) Update  e (Delete) Delete (utilizado para delete lógico apenas)
	
	ServiceRota
	(Post) Create / (Get) GetAll / (Get) Get / (Post) Update  e (Delete) Delete (utilizado para delete lógico apenas)
	
	ServiceRotaToggle
	(Post) Create / (Get) GetAll / (Get) Get / (Post) Update  e (Delete) Delete (utilizado para delete lógico apenas)
	
	Order
	(Post) Register / (Get) GetAll e (Get) Get 
	
- Utilizei o Postman para chamadas das APIs

# Build
- Build com Visual Studio 2017

# Ambiente
Localhost = http://localhost:8080

# Apis
Biblioteca do Postman:  https://www.getpostman.com/collections/fac059e56b79892b73e6

# Controller - ServiceRota
# Request (Json) - Create
- [Post]
- Url: {Localhost}/api/servicerota

Json
{ 
	"rota" : "/api/service/e"
}

# Response  (Json) - Create
Json
{
    "retorno": {
        "id": 1005,
        "rota": "/api/service/e",
        "authorization": "470ca4ff-479b-4100-8ffa-76fee7f0162b",
        "active": true
    },
    "mensagem": "Criado com sucesso."
}

# Response  (Json) - Create - Algumas Validações
Json
{
    "Rota": [
        "Campo obrigatório"
    ]
}

# Request (Json) - Get All
- [Get]
- Url: {Localhost}/api/servicerota

# Response (Json) - Get All
Json
{
    "retorno": [
        {
            "id": 1,
            "rota": "/api/service/a",
            "authorization": "cf7814bd-895f-46eb-9546-e3463c9576e4",
            "active": true
        },
        {
            "id": 2,
            "rota": "/api/service/b",
            "authorization": "2b1a594d-6de5-489c-b49c-8c32dcdcc885",
            "active": true
        },
        {
            "id": 3,
            "rota": "/api/service/c",
            "authorization": "7ed5ce47-9f65-4c4c-b3e6-46d5f2c1691b",
            "active": true
        }
    ],
    "mensagem": "Sucesso"
}

# Request (Json) - Get
- [Get]
- Url: {Localhost}/api/servicerota/{id}

# Response (Json) - Get
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Get - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Request (Json) - Update
- [Post]
- Url: {Localhost}/api/servicerota/{id}

Json
{
	"rota" : "/api/service/xpto"
}

# Response (Json) - Update
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Update - Algumas Validações
Json
{
    "Rota": [
        "Campo obrigatório"
    ]
}
	
# Request (Json) - Delete
- [Delete]	
- Url: {Localhost}/api/servicerota/{id}	

# Response (Json) - Delete
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Controller - Toggle
# Request (Json) - Create
- [Post]
- Url: {Localhost}/api/toggle

Json
{ 
	"description" : "IsButtonGreen",
	"flag" : true,
	"IdsServiceRota": [1,2,3]
}

# Response  (Json) - Create
Json
{
    "retorno": {
        "id": 1004,
        "description": "IsButtonGreen",
        "flag": true,
        "active": true,
        "serviceRotas": [
            {
                "id": 1,
                "rota": "/api/service/a",
                "authorization": "cf7814bd-895f-46eb-9546-e3463c9576e4",
                "active": true
            },
            {
                "id": 2,
                "rota": "/api/service/b",
                "authorization": "2b1a594d-6de5-489c-b49c-8c32dcdcc885",
                "active": true
            },
            {
                "id": 3,
                "rota": "/api/service/c",
                "authorization": "7ed5ce47-9f65-4c4c-b3e6-46d5f2c1691b",
                "active": true
            }
        ]
    },
    "mensagem": "Criado com sucesso."
}

# Response  (Json) - Create - Algumas Validações
Json
{
    "IdsServiceRota": [
        "Campo obrigatório"
    ]
}

# Request (Json) - Get All
- [Get]
- Url: {Localhost}/api/toggle

# Response (Json) - Get All
Json
{
    "retorno": [
        {
            "id": 1,
            "description": "isButtonBlue",
            "flag": true,
            "active": true,
            "serviceRotas": []
        },
        {
            "id": 2,
            "description": "IsButtonGreen",
            "flag": false,
            "active": true,
            "serviceRotas": [
                {
                    "id": 4,
                    "rota": "/api/service/xpto",
                    "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
                    "active": false
                },
                {
                    "id": 1004,
                    "rota": "/api/service/e",
                    "authorization": "b323ab4e-08cc-4cd0-9c2c-83b1369dbe53",
                    "active": true
                }
            ]
        },
        {
            "id": 3,
            "description": "isButtonGreen",
            "flag": true,
            "active": true,
            "serviceRotas": [
                {
                    "id": 4,
                    "rota": "/api/service/xpto",
                    "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
                    "active": false
                }
            ]
        }
    ],
    "mensagem": "Sucesso"
}

# Request (Json) - Get
- [Get]
- Url: {Localhost}/api/toggle/{id}

# Response (Json) - Get
Json
{
    "retorno": {
        "id": 2,
        "description": "IsButtonGreen",
        "flag": false,
        "active": true,
        "serviceRotas": [
            {
                "id": 4,
                "rota": "/api/service/xpto",
                "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
                "active": false
            },
            {
                "id": 1004,
                "rota": "/api/service/e",
                "authorization": "b323ab4e-08cc-4cd0-9c2c-83b1369dbe53",
                "active": true
            }
        ]
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Get - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Request (Json) - Update
- [Post]
- Url: {Localhost}/api/toggle/{id}

Json
{
	"rota" : "/api/service/xpto"
}

# Response (Json) - Update
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Update - Algumas Validações
Json
{
    "Rota": [
        "Campo obrigatório"
    ]
}
	
# Request (Json) - Delete
- [Delete]	
- Url: {Localhost}/api/servicerota/{id}	

# Response (Json) - Delete
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Update - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Controller - ServiceRotaToggle
# Request (Json) - Create
- [Post]
- Url: {Localhost}/api/servicerotatoggle

Json
{
	"rota" : "/api/order/gravar",
	"toggleId" : "3"
}

# Response  (Json) - Create
Json
{
    "retorno": {
        "id": 5,
        "rota": "/api/order/gravar",
        "active": true,
        "toggleId": 3
    },
    "mensagem": "Criado com sucesso."
}

# Response  (Json) - Create - Algumas Validações
Json
{
    "Rota": [
        "Campo obrigatório"
    ]
}

# Request (Json) - Get All
- [Get]
- Url: {Localhost}/api/servicerotatoggle

# Response (Json) - Get All
Json
{
    "retorno": [
        {
            "id": 1,
            "rota": "/api/order/register",
            "active": true,
            "toggleId": 2
        },
        {
            "id": 3,
            "rota": "/api/service/print",
            "active": false,
            "toggleId": 3
        }
    ],
    "mensagem": "Sucesso"
}

# Request (Json) - Get
- [Get]
- Url: {Localhost}/api/servicerotatoggle/{id}

# Response (Json) - Get
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/order/gravar",
        "active": true,
        "toggleId": 3
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Get - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Request (Json) - Update
- [Post]
- Url: {Localhost}/api/servicerotatoggle/{id}

Json
{
	"rota" : "/api/service/xpto",
	"toggleId" : "3"
}

# Response (Json) - Update
Json
{
    "retorno": {
        "id": 3,
        "rota": "/api/service/xpto",
        "active": false,
        "toggleId": 3
    },
    "mensagem": "Sucesso"
}
	
# Request (Json) - Delete
- [Delete]	
- Url: {Localhost}/api/servicerotatoggle/{id}	

# Response (Json) - Delete
Json
{
    "retorno": {
        "id": 4,
        "rota": "/api/service/xpto",
        "authorization": "ea94b334-25b2-448c-924f-5e9e7f144b7b",
        "active": false
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Delete - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

Json
{
    "retorno": {
        "id": 0,
        "rota": null,
        "active": false,
        "toggleId": 0
    },
    "mensagem": "Recurso não encontrado no servidor."
}

Controller: Order
# Request (Json) - Register
- [Post]
- Url: {Localhost}/api/order/register

Headers: 
Authorization:  {Valor do Authorization gerado após Create 'ServiceRotaToggle'}

Json
{
	"descriptionProduto":"chamada"
}

# Response  (Json) - Register
Json
{
    "retorno": {
        "id": 1002,
        "protocol": "b883fe23-a450-4680-94a7-a9d335fad413",
        "descriptionToggle": "IsButtonGreen",
        "descriptionServiceRota": "/api/service/e",
        "descriptionProduto": "chamada"
    },
    "mensagem": "Criado com sucesso."
}

# Response  (Json) - Register - Algumas Validações
{
    "retorno": {
        "id": 0,
        "protocol": null,
        "descriptionToggle": null,
        "descriptionServiceRota": null,
        "descriptionProduto": null
    },
    "mensagem": "Recurso não encontrado no servidor."
}

# Request (Json) - Get All
- [Get]
- Url: {Localhost}/api/order/register

# Response (Json) - Get All
Json
{
    "retorno": [
        {
            "id": 1,
            "protocol": "4cb95a8e-3cef-4f1f-9573-2975af706ddf",
            "descriptionToggle": "isButtonBlue",
            "descriptionServiceRota": "/api/service/b",
            "descriptionProduto": "chamada"
        },
        {
            "id": 2,
            "protocol": "8be45c5d-6551-4db3-ba84-79aa63d97058",
            "descriptionToggle": "isButtonBlue",
            "descriptionServiceRota": "/api/service/abc",
            "descriptionProduto": "chamada"
        }
    ],
    "mensagem": "Sucesso"
}

# Request (Json) - Get
- [Get]
- Url: {Localhost}/api/order/register/{id}

# Response (Json) - Get
Json
{
    "retorno": {
        "id": 1,
        "protocol": "4cb95a8e-3cef-4f1f-9573-2975af706ddf",
        "descriptionToggle": "isButtonBlue",
        "descriptionServiceRota": "/api/service/b",
        "descriptionProduto": "chamada"
    },
    "mensagem": "Sucesso"
}

# Response  (Json) - Get - Algumas Validações
Json
{
    "retorno": null,
    "mensagem": "Identificar inválido"
}

# Outras informações
Não tratei problemas relacionados a timeout

# Autor
Orlando Linhares de Oliveira
