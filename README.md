# JWT-Claim-AspNet-MVC-Responsivo-MySQL

Exemplo de utilização de AdminLTE na Autorização de Segurança Claims e JWT com geração do Token para Segurança na Navegação em MVC com banco de dados MySQL.

## AdminLTE em (https://adminlte.io/ )

* Template Responsivo AdminLTE 3.2 - rc

  - [AdminLTE](https://github.com/ColorlibHQ/AdminLTE/archive/refs/tags/v3.2.0-rc.zip)

## Requisitos

Baixar Pacote de Distribuição de Download da biblioteca e descompactar

Criar uma nova pasta chamada adminlte no Solution do Projeto
- Acessar o diretorio na pasta AdminLTE-3.2.0-rc /dist ->  Arrastar as pastas (css), (img) e (js) e Colar dentro da pasta adminlte
- Acessar AdminLTE-3.2.0-rc /plugins -> Arrastar a pasta (plugins) e Colar dentro da pasta adminlte

Ficara com a seguinte estrutura 

**Solution** Pasta na Raiz do Projeto 
```
| --- adminlte
     |-------- css
     |---------img 
     |---------js
     |---------plugins
```

## O que você vai encontrar neste projeto

- **AdminLTE** - Layout Responsivo JavaScript e uso de bibliotecas (Plugins).
- **Dicionário de Dados** - Contexto definido realizado manualmente com T-SQL.
- **Claims** - Autorização com contexto Header para compartilhar dados da aplicação com segurança.
- **JWT Token** - Segurança na navegação com uso criptografado de sessão do navegador.

## Execução da aplicação

Para executar a aplicação é necessário a execução do Script do MySql. 

### String de conexão do banco

Modifique a string de conexão no arquivo **Web.config**, no trecho indicado:

```bash
...
		server=127.0.0.1;userid=root;password=SUASENHA;database=SEUBANCO;persistsecurityinfo=True;
...

```

O script para criação da tabela do exemplo encontra-se na pasta **Database**.

#### Aqui está uma demonstração do Projeto

<img width="1333" height="612" alt="19 04 2026_19 13 55_REC" src="https://github.com/user-attachments/assets/3c9cdbbe-cc65-46ed-97bd-d335ed109cd2" />


