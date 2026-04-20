#  Apêndices

## 📄 Exemplos de Requisições JSON Utilizadas nos Testes

Esta seção apresenta exemplos de requisições utilizadas para testar os endpoints da API, contemplando operações de cadastro (POST) e atualização (PUT).

---

### 🔹Fabricante

**POST** `/api/Fabricantes`

```json
{
  "nome": "Toyota",
  "paisOrigem": "Japão"
}
```
**PUT** `/api/Fabricantes/{id}`

```json
{
  "idFabricante": 1,
  "nome": "Toyota Atualizada",
  "paisOrigem": "Japão"
}
```

### 🔹Categoria de Veículo

**POST** `/api/CategoriasVeiculo`

```json
{
  "nome": "SUV",
  "valorDiariaBase": 150.00
}
```
**PUT** `/api/CategoriasVeiculo/{id}`

```json
{
  "idCategoria": 1,
  "nome": "SUV Premium",
  "valorDiariaBase": 180.00
}
```

### 🔹Veículo

**POST** `/api/Veiculos`

```json
{
  "modelo": "Corolla",
  "anoFabricacao": 2022,
  "quilometragem": 25000,
  "placa": "ABC1234",
  "cor": "Preto",
  "disponivel": true,
  "idFabricante": 1,
  "idCategoria": 1
}
```

**PUT** `/api/Veiculos/{id}`

```json
{
  "idVeiculo": 1,
  "modelo": "Corolla Atualizado",
  "anoFabricacao": 2022,
  "quilometragem": 26000,
  "placa": "ABC1234",
  "cor": "Preto",
  "disponivel": true,
  "idFabricante": 1,
  "idCategoria": 1
}
```

### 🔹Cliente

**POST** `/api/Clientes`

```json
{
  "nome": "Matheus Henrique",
  "cpf": "12345678900",
  "email": "matheus.henrique@gmail.com",
  "telefone": "31999999999"
}
```
**PUT** `/api/Clientes/{id}`

```json
{
  "idCliente": 1,
  "nome": "Matheus Henrique Atualizado",
  "cpf": "12345678900",
  "email": "matheushr.atualizado@gmail.com",
  "telefone": "31999999999"
}
```
---

### Observações

- Os campos de ID (`idFabricante`, `idCategoria`, `idCliente`, etc.) são gerados automaticamente pelo banco de dados e **não devem ser enviados nas requisições POST**.
- Nas requisições PUT, o ID deve ser informado tanto na URL quanto no corpo da requisição.
- Os valores de chave estrangeira (`idFabricante`, `idCategoria`, etc.) devem existir previamente no banco de dados.
- As requisições utilizam apenas os identificadores das entidades relacionadas, evitando o envio de objetos completos e prevenindo conflitos com o Entity Framework.
- As datas seguem o padrão ISO 8601 (`yyyy-MM-ddTHH:mm:ss`).
- Durante os testes, foi necessário ajustar as propriedades de navegação das entidades para evitar erros de validação e inconsistências nos relacionamentos.

Os exemplos apresentados nesta seção foram utilizados durante a execução dos testes descritos na seção [Testes e Validação](docs/06-Testes-Validacao.md).
