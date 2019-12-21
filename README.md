# Book Manager

Crie uma API Restful em .NET Core 2.0 ou maior utilizando boas práticas da OPP, na qual consiste em gerenciar livros dos autores que possuem mais de *30 anos de idade*. Um autor pode ter *nenhum ou muitos livros*, mas *um livro nunca é escrito por dois ou mais autores*. Um autor é composto de *nome, data nascimento e identificação (RG ou CPF)*. Já *um livro é composto por título, data de lançamento, ISBN, categoria e autor*. *Todo livro possui um identificador único* mundialmente conhecido como *ISBN que tem como padrão XXX-XX-XXX-XXXX-X*.

Utilize DDD e CQRS para estruturar seu projeto. Além disso, todo comando, além de salvar no banco de dados (relacional) o objeto deve ser enviado para um EventBus(Fila). Além disso, os dados dos autores precisam estar em cache e sempre atualizados. Ou seja, no momento em que um comando para livro for executado, os dados do autor deve ser pego no cache.

Utilize SQL Server como banco de dados. O projeto deve ser possível rodar em qualquer máquina com docker. As instruções para execução deve estar no readme. 

Lembre-se de versionar o seu código utilizando git e hospede-o no GitHub. No início do projeto já crie o repositório e nos envie o link, mesmo ele vazio. Ao decorrer do projeto faça commits e de push.

__Diferenciais em ordem de prioridade:__
* Testes;
* Logger;
* Consumir as mensagens da fila e guardar os dados no MongoDB;
* Autenticação no sistema com Identity.

Defina um prazo estimado para realizar o projeto e nos envie para acompanharmos.
