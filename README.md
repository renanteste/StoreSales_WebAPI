# StoreSalesAPI - ASP.NET Core Web API

Este é um projeto de API Web criado com ASP.NET Core e .NET 8.0, destinado a gerenciar as vendas de uma loja, incluindo a funcionalidade de registrar, consultar, atualizar e cancelar vendas. A API segue uma arquitetura limpa e é projetada para ser escalável e facilmente testável.

## Funcionalidades

- **CRUD de Vendas**: Criar, Ler, Atualizar e Deletar registros de vendas.
- **Gestão de Produtos e Itens**: Gerenciar produtos vendidos, com detalhes de quantidade, preço unitário e descontos.
- **Cálculo de Descontos**: Aplica regras de descontos baseadas na quantidade de itens comprados.
- **Cancelamento de Vendas**: Permite cancelar uma venda registrada.
- **Eventos (Opcional)**: Publicação de eventos relacionados a mudanças nas vendas, como criação, modificação ou cancelamento.

### Regras de Negócio

- Compras acima de 4 itens idênticos têm 10% de desconto.
- Compras entre 10 e 20 itens idênticos têm 20% de desconto.
- Não é permitido vender mais de 20 itens idênticos de um mesmo produto.
- Compras abaixo de 4 itens não têm direito a desconto.

## Instruções de Configuração

### Pré-requisitos

1. **Visual Studio 2022** com **.NET 8.0 SDK** instalado.
2. **SQL Server** ou outro banco de dados de sua escolha (as configurações podem ser alteradas no arquivo `appsettings.json`).
3. **Ferramenta de Testes**: Pode-se usar o **Postman** ou qualquer cliente REST para testar a API.

### Passos para Instalação

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/renanteste/StoreSalesAPI.git

