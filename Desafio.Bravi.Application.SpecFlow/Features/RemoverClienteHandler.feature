Feature: RemoverClienteHandler

Scenario: Remover Cliente
	Given que ao remover um cliente seja informado o identificador '63bf0533315982662670330f'
	When remover o cliente
	Then a exclusao será encerrada sem erros