Feature: EditarClienteHandler

Scenario: Editar Cliente
	Given que sejam informados os dados na edicao
	| Key	|Value |
	| Identificador | 63bf0533315982662670330f |
	| Nome | Hygor de Lima Azevedo |
	| CodigoAreaTelefone | 31 | 
	| NumeroTelefone | 998765432 |
	| Email | hygor.azevedo@desafio.bravi | 
	| CodigoAreaWhatsApp | 31 |
	| NumeroWhatsApp | 998765432 |
	When editar o cliente
	Then a edicao sera encerrada sem erros