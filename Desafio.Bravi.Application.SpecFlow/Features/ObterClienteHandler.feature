Feature: ObterClienteHandler

@mytag
Scenario: Obter Todos Clientes
	Given que seja informado o identificador ''
	When consulta os clientes
	Then retorna a lista completa de clientes

@mytag
Scenario: Obter Cliente Por Identificador Existente
	Given que seja informado o identificador '63be59af70be3df5ab1ae2a8'
	When consulta os clientes
	Then retorna a lista completa de clientes

@mytag
Scenario: Obter Cliente Por Identificador Inexistente
	Given que seja informado o identificador '63be59af70be3df5ab1ae2a0'
	When consulta os clientes
	Then retorna a lista de clientes vazia