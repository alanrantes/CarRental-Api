# Requisitos Funcionais

## Visão Geral

<p align="justify">O sistema de locadora de veículos tem como objetivo permitir o gerenciamento das principais entidades envolvidas no processo de locação, incluindo fabricantes, categorias de veículos, veículos, clientes e aluguéis.</p>

<p align="justify">Nesta etapa do projeto, foram implementadas as estruturas de dados e o banco de dados que suportam essas operações, preparando a base para a construção das funcionalidades da API.</p>

---

## Funcionalidades do Sistema

As funcionalidades previstas para o sistema incluem:

### 🔹Gerenciamento de Fabricantes
- Cadastro de fabricantes de veículos;
- Consulta de fabricantes cadastrados;
- Atualização de informações;
- Remoção de registros.

### 🔹Gerenciamento de Categorias de Veículos
- Cadastro de categorias;
- Consulta de categorias existentes;
- Atualização e exclusão de categorias.

### 🔹Gerenciamento de Veículos
- Cadastro de veículos com informações como modelo, ano de fabricação, quilometragem, placa e disponibilidade;
- Associação do veículo a um fabricante e a uma categoria;
- Consulta e atualização de dados dos veículos;
- Remoção de veículos.

### 🔹Gerenciamento de Clientes
- Cadastro de clientes com nome, CPF e e-mail;
- Consulta de clientes cadastrados;
- Atualização de informações;
- Exclusão de clientes.

### 🔹Gerenciamento de Aluguéis
- Registro de novos aluguéis vinculando cliente e veículo;
- Definição do período de locação;
- Registro de quilometragem inicial e final;
- Armazenamento de valores de diária e total;
- Atualização do status do aluguel.

---

## Casos de Uso Principais

### 🔹Cadastro de Veículo
1. O usuário informa os dados do veículo;
2. O sistema associa o veículo a um fabricante e a uma categoria;
3. O veículo é armazenado no banco de dados.

---

### 🔹Cadastro de Cliente
1. O usuário informa os dados do cliente;
2. O sistema valida as informações obrigatórias;
3. O cliente é registrado no banco de dados.

---

### 🔹Registro de Aluguel
1. O usuário seleciona um cliente e um veículo;
2. O sistema registra a data de retirada e a data prevista de devolução;
3. O sistema armazena a quilometragem inicial;
4. O aluguel é registrado no sistema.

---

### 🔹Atualização de Aluguel (Devolução)
1. O usuário informa a devolução do veículo;
2. O sistema registra a quilometragem final;
3. O sistema atualiza o valor total e o status do aluguel;
4. O veículo pode ser marcado como disponível novamente.

---

## Considerações

<p align="justify">Os requisitos funcionais apresentados refletem as funcionalidades básicas necessárias para o funcionamento de um sistema de locadora de veículos. A implementação completa dessas funcionalidades será realizada nas etapas seguintes do projeto, por meio da construção dos endpoints da API e da integração com o banco de dados.</p>
