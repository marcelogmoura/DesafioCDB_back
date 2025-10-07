# Desafio T�cnico - CDB

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-512BD4?style=flat&logo=csharp&logoColor=white)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=flat&logo=angular&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![Tests](https://img.shields.io/badge/xUnit-802580?style=flat&logo=xunit&logoColor=white)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

---

## ?? Documenta��o
O enunciado original do desafio pode ser encontrado aqui:
[**Desafio de C�lculo de CDB (PDF)**](./Pdf/DesafioCDB.pdf)

---

## ? Objetivo do Desafio

Este projeto foi desenvolvido como parte de um **teste de avalia��o para desenvolvedor**, focado na aplica��o dos princ�pios **SOLID**, **Testes Unit�rios** (com cobertura **> 90%** na camada de neg�cio), **boas pr�ticas de codifica��o** e **containeriza��o** com **Docker**.

O sistema implementa uma solu��o completa para o c�lculo do **Certificado de Dep�sito Banc�rio (CDB)**, incluindo uma Web API (.NET Core) para a l�gica e um frontend (Angular) para intera��o, garantindo qualidade de c�digo e testes robustos.

---

## ??? Tecnologias Utilizadas

| Categoria | Tecnologia | Vers�o/Framework |
| :--- | :--- | :--- |
| **Backend** | **ASP.NET Core** | 9.0 (ou a vers�o que voc� usou) |
| **Linguagem** | **C#** | 12.0 (ou a vers�o que voc� usou) |
| **Frontend** | **Angular** | 17+ (ou a vers�o que voc� usou) |
| **Testes** | **xUnit** | - |
| **Containeriza��o** | **Docker** e **Docker Compose** | - |
| **Padr�es** | **SOLID**, **Clean Architecture** (adaptada), **DTOs** | - |

---

## ??? Arquitetura da Solu��o

A API segue um padr�o de arquitetura em camadas para garantir a **separa��o de responsabilidades** e ader�ncia aos princ�pios **SOLID**.

| Camada | Projeto | Responsabilidade Principal |
| :--- | :--- | :--- |
| **Application** | `DesafioCDB.API` | Ponto de entrada (Controller), configura��o de inje��o de depend�ncia e *CORS*. |
| **Domain** | `DesafioCDB.Domain` | Cont�m a regra de neg�cio (`CdbService`), DTOs e Interfaces. **� a camada principal de l�gica de neg�cio testada.** |
| **Tests** | `DesafioCDB.Tests` | Testes unit�rios utilizando **xUnit** com alta cobertura na camada de *Domain*. |
| **Frontend** | `DesafioCDB.Web` | Interface de usu�rio desenvolvida em **Angular CLI** para consumir a API. |

---

## ?? Regra de Neg�cio (C�lculo do CDB)

O c�lculo do rendimento do CDB segue uma l�gica b�sica de juros compostos, aplicando as al�quotas de Imposto de Renda (IR) regressivas, baseadas no tempo de perman�ncia do investimento.

**A l�gica aplicada �:**

1.  **C�lculo do Rendimento Bruto:** Juros Compostos sobre o valor inicial.
2.  **Aplica��o do IR (Al�quotas Regressivas):** O IR � aplicado sobre o *lucro* (rendimento bruto - valor inicial), conforme a tabela:
    | Prazo | Al�quota de IR |
    | :--- | :--- |
    | At� 180 dias | 22.5% |
    | De 181 a 360 dias | 20.0% |
    | De 361 a 720 dias | 17.5% |
    | Acima de 720 dias | 15.0% |

---

## ?? Endpoints da API

A API exp�e um �nico endpoint para o c�lculo, que recebe o valor de investimento e a quantidade de meses.

| M�todo | Endpoint | Descri��o | Par�metros (JSON Body) |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/cdb` | Calcula o rendimento do CDB (Bruto e L�quido) com base no valor e no prazo. | `{ "valorInicial": 1000.0, "prazoMeses": 12 }` |

---

## ?? Como Executar a Solu��o (Containeriza��o)

A solu��o utiliza **Docker Compose** para orquestrar a Web API (.NET) e o Frontend (Angular/Nginx), facilitando a execu��o em qualquer ambiente.

### Pr�-requisitos

* **Docker Desktop** instalado e em execu��o.

### Instru��es

1.  **Navegue at� o Diret�rio Raiz:** Abra o terminal na raiz da solu��o (onde o arquivo `docker-compose.yml` est� localizado).

2.  **Construa e Suba os Containers:**
    Execute o comando para construir as imagens e iniciar os servi�os em modo *detached*:

    ```bash
    docker compose up --build -d
    ```

3.  **Acesse a Aplica��o:**
    Ap�s a inicializa��o (pode levar alguns segundos), acesse o Frontend no seu navegador:

    ```
    http://localhost:80
    ```

4.  **Parar e Remover Containers:**
    Para encerrar a execu��o e remover os containers e redes:

    ```bash
    docker compose down
    ```

---

## ?? Licen�a

Este projeto est� sob a licen�a **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## ????? Autor

**Marcelo Moura**

* ?? **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com) | [admin@allriders.com.br](mailto:admin@allriders.com.br)
* ?? **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)
* ?? **LinkedIn:** [linkedin.com/in/marcelogmoura](https://www.linkedin.com/in/marcelogmoura/)