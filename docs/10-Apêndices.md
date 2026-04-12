#  Apêndices

## 📄 Exemplos de Requisições JSON

Esta seção apresenta exemplos de requisições utilizadas para testar os endpoints da API.

---

### 🏭 Fabricante

**POST** `/api/Fabricantes`

```json
{
  "idFabricante": 0,
  "nome": "Toyota",
  "paisOrigem": "Japão"
}
```
### 🏷️ Categoria de Veículo

**POST** `/api/CategoriasVeiculo`

```json
{
  "idCategoria": 0,
  "nome": "SUV",
  "valorDiariaBase": 150.00
}
```

### 🚗 Veículo

**POST** `/api/Veiculos`

```json
{
  "idVeiculo": 0,
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

### 👤 Cliente

**POST** `/api/Clientes`

```json
{
  "idCliente": 0,
  "nome": "Alan Lacerda",
  "cpf": "12345678900",
  "email": "alan@email.com",
  "telefone": "31999999999"
}
```

### 📄 Aluguel

**POST** `/api/Alugueis`

```json
{
  "idAluguel": 0,
  "dataRetirada": "2026-04-12T10:00:00",
  "dataPrevistaDevolucao": "2026-04-15T10:00:00",
  "dataDevolucao": null,
  "quilometragemInicial": 25000,
  "quilometragemFinal": null,
  "valorDiaria": 150.00,
  "valorTotal": 450.00,
  "status": "Ativo",
  "idCliente": 1,
  "idVeiculo": 1
}
```

### Observações

- Os campos de ID (`idFabricante`, `idCategoria`, etc.) são gerados automaticamente pelo banco de dados.
- Os valores de chave estrangeira (`idCliente`, `idVeiculo`, etc.) devem existir previamente no banco.
- Datas seguem o padrão ISO 8601 (`yyyy-MM-ddTHH:mm:ss`).
- Campos como dataDevolucao e `quilometragemFinal` podem ser null no momento da criação do aluguel.
