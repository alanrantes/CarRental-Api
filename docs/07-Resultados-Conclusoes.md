# Resultados e Conclusões

## Análise dos Resultados

O desenvolvimento do sistema de locadora de veículos permitiu a implementação completa de uma API RESTful funcional, atendendo aos principais requisitos definidos nas etapas iniciais do projeto.

Durante os testes realizados, foi possível validar o correto funcionamento das operações de CRUD (Create, Read, Update e Delete) para todas as entidades do sistema, incluindo fabricantes, categorias, veículos, clientes e aluguéis.

Além disso, foram testadas regras de negócio importantes, como:

- Verificação da existência de cliente e veículo antes da criação de um aluguel;
- Controle de disponibilidade dos veículos;
- Atualização do status do aluguel e registro de devolução;
- Recuperação de dados relacionados através de consultas com joins.

Os resultados obtidos demonstram que a API responde corretamente às requisições, garantindo consistência e integridade dos dados.

---

## Avaliação da Conformidade dos Requisitos

Com base nos testes realizados, foi possível verificar que os principais requisitos funcionais do sistema foram atendidos, incluindo:

- Cadastro e gerenciamento de veículos;
- Cadastro de clientes;
- Registro e controle de aluguéis;
- Integração com banco de dados relacional (SQL Server);
- Implementação de endpoints RESTful;
- Validação de dados de entrada;
- Implementação de consultas com relacionamentos entre tabelas (joins);
- Utilização do Swagger para testes e documentação da API.

Dessa forma, o sistema apresenta conformidade com os requisitos propostos, demonstrando que os objetivos definidos foram alcançados.

---

## Conclusões

O sistema desenvolvido mostrou-se eficaz no atendimento às necessidades básicas de uma locadora de veículos, permitindo o gerenciamento estruturado de dados e a execução de operações essenciais de forma organizada e consistente.

A utilização de tecnologias como ASP.NET Core e Entity Framework Core contribuiu para o desenvolvimento de uma aplicação robusta, com boa organização de código e facilidade de manutenção.

Além disso, a implementação de regras de negócio e validações garantiu maior confiabilidade no sistema, evitando inconsistências e erros durante a manipulação dos dados.

De forma geral, o projeto permitiu a aplicação prática de conceitos fundamentais de desenvolvimento backend, como criação de APIs REST, modelagem de banco de dados e integração entre aplicação e banco relacional.

Como possível evolução, o sistema pode ser expandido com funcionalidades adicionais, como autenticação de usuários, controle de permissões e integração com interfaces front-end.
