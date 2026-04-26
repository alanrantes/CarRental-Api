# Testes e Validação

## Objetivo dos Testes

Esta seção apresenta os testes realizados na API utilizando o Swagger, com o objetivo de validar o funcionamento dos principais endpoints do sistema.

Os testes foram focados principalmente nas operações de criação (`POST`), utilizando os exemplos de requisições JSON disponíveis nos [Apêndices](10-Apendices.md).

---

## Ferramenta Utilizada

Os testes foram realizados por meio do **Swagger**, ferramenta integrada ao projeto para documentação e execução dos endpoints da API.

---

## Testes Realizados

Foram testados os principais cadastros do sistema:

- Cadastro de fabricante;
- Cadastro de categoria de veículo;
- Cadastro de veículo;
- Cadastro de cliente;
- Cadastro de aluguel.

---

##  Teste: Cadastro de Fabricante

**Endpoint testado:** `POST /api/Fabricantes`

**Objetivo:** validar o cadastro de um fabricante no banco de dados.

<p align="center">
  <img src="images/teste-post-fabricante.png" alt="Teste POST Fabricante" />
</p>

---

## 🏷️ Teste: Cadastro de Categoria de Veículo

**Endpoint testado:** `POST /api/CategoriasVeiculo`

**Objetivo:** validar o cadastro de uma categoria de veículo com valor base de diária.

![](images/)
---

## 🚗 Teste: Cadastro de Veículo

**Endpoint testado:** `POST /api/Veiculos`

**Objetivo:** validar o cadastro de um veículo vinculado a um fabricante e a uma categoria.

![](images/)
---

## 👤 Teste: Cadastro de Cliente

**Endpoint testado:** `POST /api/Clientes`

**Objetivo:** validar o cadastro de um cliente com nome, CPF, e-mail e telefone.

![](images/)
---

## 📄 Teste: Cadastro de Aluguel

**Endpoint testado:** `POST /api/Alugueis`

**Objetivo:** validar o registro de um aluguel relacionando cliente e veículo existentes no banco de dados.

![](images/)
---

## 🔍 Validação dos Resultados

Durante os testes, foi possível verificar que os endpoints responderam corretamente às requisições enviadas, retornando códigos HTTP adequados, como:

- `201 Created` para registros criados com sucesso;
- `400 Bad Request` para dados inválidos ou inconsistentes;
- `404 Not Found` para registros não encontrados, quando aplicável.

Também foi validado que as entidades relacionadas precisam existir previamente no banco de dados, como no caso do cadastro de veículos e aluguéis.

---

## Considerações

Os testes realizados demonstraram que a API está funcionando corretamente para as principais operações de cadastro. Além disso, a validação das regras de negócio, como a existência de cliente e veículo no registro de aluguel, contribui para a integridade dos dados no sistema.
