# ECommerceDio

Aplicação com arquitetura de microserviços para gerenciamento de estoque de produtos e vendas em uma plataforma de e-commerce.

## Visão Geral

Este projeto tem como objetivo demonstrar uma plataforma de e-commerce com foco nos módulos de estoque de produtos e vendas, organizada por meio de uma arquitetura de microserviços. Ele foi desenvolvido como parte de estudos/prática da plataforma Digital Innovation One (“DIO”).

## Funcionalidades

Cadastro de produtos (nome, descrição, quantidade, preço)

Controle de estoque (adição, remoção, atualização de quantidade)

Registro de vendas (itens vendidos, quantidade, total)

Integração entre os serviços (produtos ↔ estoque ↔ vendas)

Arquitetura modular, separando responsabilidades por camadas (Controllers, Services, Repositories, DTOs)

## Arquitetura & Tecnologias

Linguagem: C# (.NET) — conforme análise do repositório.

Projeto estruturado com Controllers, DTOs, Models, Repositories, Services.

Arquitetura de microserviços (ou ao menos modularizada para múltiplos domínios)

Utilização de migrations para banco de dados.

Projeto organizado em solução (.sln), facilitando manutenção e escalabilidade.
