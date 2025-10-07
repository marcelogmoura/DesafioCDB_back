# Desafio Técnico - CDB

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-512BD4?style=flat&logo=csharp&logoColor=white)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=flat&logo=angular&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![Tests](https://img.shields.io/badge/xUnit-802580?style=flat&logo=xunit&logoColor=white)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

---

## 📜 Documentação
O enunciado original do desafio pode ser encontrado aqui:
[**Desafio de Cálculo de CDB (PDF)**](./Pdf/DesafioCDB.pdf)

## ✨ O frontend (Angular) do projeto se encontra 

[https://github.com/marcelogmoura/DesafioCDB_front](https://github.com/marcelogmoura/DesafioCDB_front)
---

## ✨ Objetivo do Desafio

Este projeto foi desenvolvido como parte de um **teste de avaliação para desenvolvedor**, focado na aplicação dos princípios **SOLID**, **Testes Unitários** (com cobertura **> 90%** na camada de negócio), **boas práticas de codificação** e **containerização** com **Docker**.

O sistema implementa uma solução completa para o cálculo do **Certificado de Depósito Bancário (CDB)**, incluindo uma Web API (.NET Core) para a lógica e um frontend (Angular) para interação, garantindo qualidade de código e testes robustos.

---

## 🛠️ Tecnologias Utilizadas

| Categoria | Tecnologia | Versão/Framework |
| :--- | :--- | :--- |
| **Backend** | **ASP.NET Core** | 9.0 |
| **Linguagem** | **C#** | 12.0 |
| **Frontend** | **Angular** | 19+ |
| **Testes** | **xUnit** | - |
| **Containerização** | **Docker** e **Docker Compose** | - |
| **Padrões** | **SOLID**, **Clean Architecture** (adaptada), **DTOs** | - |

---

## 🏗️ Arquitetura da Solução

A API segue um padrão de arquitetura em camadas para garantir a **separação de responsabilidades** e aderência aos princípios **SOLID**.

| Camada | Projeto | Responsabilidade Principal |
| :--- | :--- | :--- |
| **Application** | `DesafioCDB.API` | Ponto de entrada (Controller), configuração de injeção de dependência e *CORS*. |
| **Domain** | `DesafioCDB.Domain` | Contém a regra de negócio (`CdbService`), DTOs e Interfaces. **É a camada principal de lógica de negócio testada.** |
| **Tests** | `DesafioCDB.Tests` | Testes unitários utilizando **xUnit** com alta cobertura na camada de *Domain*. |
| **Frontend** | `DesafioCDB.Web` | Interface de usuário desenvolvida em **Angular CLI** para consumir a API. |

---

## 💼 Regra de Negócio (Cálculo do CDB)

O cálculo do rendimento do CDB segue uma lógica básica de juros compostos, aplicando as alíquotas de Imposto de Renda (IR) regressivas, baseadas no tempo de permanência do investimento.

**A lógica aplicada é:**

1.  **Cálculo do Rendimento Bruto:** Juros Compostos sobre o valor inicial.
2.  **Aplicação do IR (Alíquotas Regressivas):** O IR é aplicado sobre o *lucro* (rendimento bruto - valor inicial), conforme a tabela:
    | Prazo | Alíquota de IR |
    | :--- | :--- |
    | Até 180 dias | 22.5% |
    | De 181 a 360 dias | 20.0% |
    | De 361 a 720 dias | 17.5% |
    | Acima de 720 dias | 15.0% |

---

## 🔗 Endpoints da API

A API expõe um único endpoint para o cálculo, que recebe o valor de investimento e a quantidade de meses.

| Método | Endpoint | Descrição | Parâmetros (JSON Body) |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/cdb` | Calcula o rendimento do CDB (Bruto e Líquido) com base no valor e no prazo. | `{ "valorInicial": 1000.0, "prazoMeses": 12 }` |

---

## 🚀 Como Executar a Solução (Containerização)

A solução utiliza **Docker Compose** para orquestrar a Web API (.NET) e o Frontend (Angular/Nginx), facilitando a execução em qualquer ambiente.

### Pré-requisitos

* **Docker Desktop** instalado e em execução.

### Instruções

1.  **Navegue até o Diretório Raiz:** Abra o terminal na raiz da solução (onde o arquivo `docker-compose.yml` está localizado).

2.  **Construa e Suba os Containers:**
    Execute o comando para construir as imagens e iniciar os serviços em modo *detached*:

    ```bash
    docker compose up --build -d
    ```

3.  **Acesse a Aplicação:**
    Após a inicialização (pode levar alguns segundos), acesse o Frontend no seu navegador:

    ```
    http://localhost:80
    ```

4.  **Parar e Remover Containers:**
    Para encerrar a execução e remover os containers e redes:

    ```bash
    docker compose down
    ```

---

## 🖼️ Demonstração Visual (Swagger)

As telas abaixo demonstram os request e response no swagger.

![Request](https://i.postimg.cc/WpnG5sPy/Screenshot-10.jpg)

![Response](https://i.postimg.cc/qqn9dgXs/Screenshot-11.jpg)

---


## ⚖️ Licença

Este projeto está sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

**Marcelo Moura**

* 📧 **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com) | [admin@allriders.com.br](mailto:admin@allriders.com.br)
* 🐙 **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)
* 👔 **LinkedIn:** [linkedin.com/in/marcelogmoura](https://www.linkedin.com/in/marcelogmoura/)
