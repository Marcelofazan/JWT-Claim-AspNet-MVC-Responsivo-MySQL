# JWT-Claim-AspNet-MVC-Responsivo-MySQL

Exemplo de utilização de AdminLTE na Autorização de Segurança Claims e JWT com geração do Token para Segurança na Navegação em MVC com banco de dados MySQL.

## AdminLTE em (https://adminlte.io/ )

* Template Responsivo AdminLTE 3.2 - rc

  - [AdminLTE](https://github.com/ColorlibHQ/AdminLTE/archive/refs/tags/v3.2.0-rc.zip)

## Requisitos

Baixar Pacote de Distribuição de Download da biblioteca e descompactar

Criar uma nova pasta chamada adminlte no Solution ERPSimples
- Na Pasta AdminLTE-3.2.0-rc /dist -> Copiar as pastas css, img e js e Colar dentro da pasta adminlte
- Na Pasta AdminLTE-3.2.0-rc /plugins -> Copiar a pasta plugins e Colar dentro da pasta adminlte

Outra forma: 
- Criar uma nova pasta chamada adminlte dentro da pasta /dist no pacote de distribuição 
- Copiar as pastas img / css / js / plugins
- Colar as pastas img / css / js / plugins dentro de adminlte
- Arrastar a pasta adminlte pelo Explorer em cima de Solution ERPSimples e todas pastas criaram automático.

# O que você vai encontrar neste projeto

- **AdminLTE** - Layout Responsivo JavaScript e uso de bibliotecas (Plugins). 
- **Claims** - Autorização com contexto Header para compartilhar dados da aplicação com segurança.
- **JWT Token** - Segurança na navegação com uso criptografado de sessão do navegador.

## Execução da aplicação

Para executar a aplicação é necessário a execução do Script do MySql. 

## String de conexão do banco

Modifique a string de conexão no arquivo **Web.config**, no trecho indicado:

```bash
...
		server=127.0.0.1;userid=root;password=SUASENHA;database=SEUBANCO;persistsecurityinfo=True;
...

```

O script para criação da tabela do exemplo encontra-se na pasta **Database**.
