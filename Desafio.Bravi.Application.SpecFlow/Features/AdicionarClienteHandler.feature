Feature: AdicionarClienteHandler

Scenario: Adicionar Cliente Completo
	Given que sejam informados os dados no cadastrado
	| Key	|Value |
	| Nome | Hygor de Lima Azevedo |
	| CodigoAreaTelefone | 31 | 
	| NumeroTelefone | 998765432 |
	| Email | hygor.azevedo@desafio.bravi | 
	| CodigoAreaWhatsApp | 31 |
	| NumeroWhatsApp | 998765432 |
	When adicionar o cliente
	Then o identificador do cliente sera preenchido