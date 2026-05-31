CREATE DATABASE p4g5;
GO

USE p4g5;
GO

CREATE TABLE Utilizador (
    id_utilizador  INT          PRIMARY KEY,
    email          VARCHAR(255) NOT NULL UNIQUE,
    password_hash  VARCHAR(255) NOT NULL
);

CREATE TABLE Evento (
    id_evento   INT          PRIMARY KEY,
    nome        VARCHAR(255) NOT NULL,
    data_inicio DATE         NOT NULL,
    data_fim    DATE         NOT NULL
);

CREATE TABLE Setor (
    id_setor  INT PRIMARY KEY,
    id_evento INT NOT NULL,
    FOREIGN KEY (id_evento) REFERENCES Evento(id_evento)
);

CREATE TABLE Stand (
    id_stand  INT            PRIMARY KEY,
    area_m2   DECIMAL(10, 2) NOT NULL,
    id_setor  INT            NOT NULL,
    FOREIGN KEY (id_setor) REFERENCES Setor(id_setor)
);

CREATE TABLE Tipo_de_Acesso (
    id_tipo      INT          PRIMARY KEY,
    nome_perfil  VARCHAR(255) NOT NULL
);

CREATE TABLE Token (
    id_token   INT          PRIMARY KEY,
    codigo_qr  VARCHAR(255) NOT NULL UNIQUE,
    status     VARCHAR(50)  NOT NULL,
    id_tipo    INT          NOT NULL,
    FOREIGN KEY (id_tipo) REFERENCES Tipo_de_Acesso(id_tipo)
);

CREATE TABLE Participante (
    id_participante  INT          PRIMARY KEY,
    nif              VARCHAR(20)  NOT NULL UNIQUE,
    nome_completo    VARCHAR(255) NOT NULL,
    telemovel        VARCHAR(20)  NULL,
    id_evento        INT          NOT NULL,
    FOREIGN KEY (id_evento) REFERENCES Evento(id_evento)
);

CREATE TABLE Expositor (
    id_participante       INT          PRIMARY KEY,
    nome_empresa          VARCHAR(255) NULL,
    id_stand              INT          NULL,
    data_inicio_ocupacao  DATE         NULL,
    FOREIGN KEY (id_participante) REFERENCES Participante(id_participante),
    FOREIGN KEY (id_stand)        REFERENCES Stand(id_stand)
);

CREATE TABLE Visitante (
    id_participante  INT          PRIMARY KEY,
    profissao        VARCHAR(255) NULL,
    FOREIGN KEY (id_participante) REFERENCES Participante(id_participante)
);


CREATE TABLE Venda (
    id_venda       INT            PRIMARY KEY,
    data_emissao   DATE           NOT NULL,
    valor_total    DECIMAL(10, 2) NOT NULL,
    id_utilizador  INT            NOT NULL,
    FOREIGN KEY (id_utilizador) REFERENCES Utilizador(id_utilizador)
);

CREATE TABLE Ingresso (
    id_token        INT            PRIMARY KEY,
    preco_pago      DECIMAL(10, 2) NOT NULL,
    data_validade   DATE           NULL,
    id_venda        INT            NOT NULL,
    id_participante INT            NOT NULL,
    FOREIGN KEY (id_token)        REFERENCES Token(id_token),
    FOREIGN KEY (id_venda)        REFERENCES Venda(id_venda),
    FOREIGN KEY (id_participante) REFERENCES Participante(id_participante)
);

CREATE TABLE Pagamento (
    id_pagamento  INT            PRIMARY KEY,
    metodo        VARCHAR(100)   NOT NULL,
    referencia    VARCHAR(255)   NULL,
    valor         DECIMAL(10, 2) NOT NULL,
    id_venda      INT            NOT NULL,
    FOREIGN KEY (id_venda) REFERENCES Venda(id_venda)
);

CREATE TABLE Ponto_de_Acesso (
    id_ponto_de_acesso  INT          PRIMARY KEY,
    designacao          VARCHAR(255) NOT NULL,
    sentido             VARCHAR(50)  NULL,
    id_setor            INT          NOT NULL,
    FOREIGN KEY (id_setor) REFERENCES Setor(id_setor)
);

CREATE TABLE Validacao (
    id_validacao        INT          PRIMARY KEY,
    codigo_lido         VARCHAR(255) NOT NULL,
    data_hora           TIMESTAMP    NOT NULL,
    resultado           VARCHAR(50)  NOT NULL,
    id_ponto_de_acesso  INT          NOT NULL,
    id_token            INT          NOT NULL,
    FOREIGN KEY (id_ponto_de_acesso) REFERENCES Ponto_de_Acesso(id_ponto_de_acesso),
    FOREIGN KEY (id_token)           REFERENCES Token(id_token)
);

