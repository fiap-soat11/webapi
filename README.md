# WebApi
Reposiório destinado à api da lanchonete

## Instruções para construir a imagem Docker da aplicação

Acesse a pasta "fiap-soat11" e execute o comando abaixo:

```bash
docker build -t fiap-soat11:v2 .
```

## Instruções para construir a imagem Docker do banco de dados

Acesse a pasta "mysql" e execute o comando abaixo:

```bash
docker build -t fiap-soat11-db:v2 .
```

## Instruções para executar com Docker Compose

1. Certifique-se de ter um arquivo `docker-compose.yml` na raiz do projeto.
2. Execute o comando abaixo para subir os serviços:

```bash
docker-compose up
```

3. Para rodar em segundo plano (modo detached):

```bash
docker-compose up -d
```

4. Para parar os serviços:

```bash
docker-compose down
```
