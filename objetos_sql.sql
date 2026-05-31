USE [p4g5]
GO

-- ============================================================
-- VIEWS
-- ============================================================

CREATE OR ALTER VIEW dbo.vw_Participantes AS
SELECT p.id_participante, p.nif, p.nome_completo, p.telemovel, p.id_evento,
       CASE
           WHEN ex.id_participante IS NOT NULL THEN 'Expositor'
           WHEN vi.id_participante IS NOT NULL THEN 'Visitante'
           ELSE '?'
       END AS tipo,
       ex.nome_empresa, ex.id_stand, vi.profissao
FROM dbo.Participante p
LEFT JOIN dbo.Expositor ex ON ex.id_participante = p.id_participante
LEFT JOIN dbo.Visitante vi ON vi.id_participante = p.id_participante
GO

CREATE OR ALTER VIEW dbo.vw_Tokens AS
SELECT t.id_token, t.codigo_qr, t.status, t.id_tipo, ta.nome_perfil AS tipo
FROM dbo.Token t
INNER JOIN dbo.Tipo_de_Acesso ta ON ta.id_tipo = t.id_tipo
GO

CREATE OR ALTER VIEW dbo.vw_Vendas AS
SELECT v.id_venda, v.data_emissao, v.valor_total,
       u.email AS utilizador,
       (SELECT COUNT(*) FROM dbo.Ingresso i WHERE i.id_venda = v.id_venda) AS n_ingressos
FROM dbo.Venda v
INNER JOIN dbo.Utilizador u ON u.id_utilizador = v.id_utilizador
GO

CREATE OR ALTER VIEW dbo.vw_Setores AS
SELECT s.id_setor, s.id_evento, e.nome AS evento
FROM dbo.Setor s
INNER JOIN dbo.Evento e ON e.id_evento = s.id_evento
GO

CREATE OR ALTER VIEW dbo.vw_HistoricoValidacoes AS
SELECT TOP 100 v.id_validacao, v.codigo_lido, v.resultado,
       pa.designacao AS ponto
FROM dbo.Validacao v
INNER JOIN dbo.Ponto_de_Acesso pa ON pa.id_ponto_de_acesso = v.id_ponto_de_acesso
ORDER BY v.id_validacao DESC
GO


-- ============================================================
-- INDEXES
-- ============================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Validacao_Token' AND object_id = OBJECT_ID('dbo.Validacao'))
    CREATE INDEX idx_Validacao_Token ON dbo.Validacao (id_token)

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Ingresso_Venda' AND object_id = OBJECT_ID('dbo.Ingresso'))
    CREATE INDEX idx_Ingresso_Venda ON dbo.Ingresso (id_venda)

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Participante_Evento' AND object_id = OBJECT_ID('dbo.Participante'))
    CREATE INDEX idx_Participante_Evento ON dbo.Participante (id_evento)
GO


-- ============================================================
-- TRIGGERS
-- ============================================================

CREATE OR ALTER TRIGGER trg_ValidarDatasEvento
ON dbo.Evento
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE data_fim < data_inicio)
    BEGIN
        RAISERROR('A data de fim tem de ser maior ou igual à data de início.', 16, 1)
        ROLLBACK
    END
END
GO


-- ============================================================
-- STORED PROCEDURES
-- ============================================================

CREATE OR ALTER PROCEDURE dbo.sp_Login
    @email VARCHAR(255),
    @pass  VARCHAR(255)
AS
BEGIN
    SELECT COUNT(*) AS resultado
    FROM dbo.Utilizador
    WHERE email = @email AND password_hash = @pass
END
GO

-- ── Evento ──────────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarEvento
    @id   INT,
    @nome VARCHAR(255),
    @di   DATE,
    @df   DATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Evento WHERE id_evento = @id)
        UPDATE dbo.Evento
        SET nome = @nome, data_inicio = @di, data_fim = @df
        WHERE id_evento = @id
    ELSE
        INSERT INTO dbo.Evento (id_evento, nome, data_inicio, data_fim)
        VALUES (@id, @nome, @di, @df)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarEvento
    @id INT
AS
BEGIN
    DELETE FROM dbo.Evento WHERE id_evento = @id
END
GO

-- ── Setor ───────────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarSetor
    @id INT,
    @ev INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Setor WHERE id_setor = @id)
        UPDATE dbo.Setor SET id_evento = @ev WHERE id_setor = @id
    ELSE
        INSERT INTO dbo.Setor (id_setor, id_evento) VALUES (@id, @ev)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarSetor
    @id INT
AS
BEGIN
    DELETE FROM dbo.Setor WHERE id_setor = @id
END
GO

-- ── Stand ───────────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarStand
    @id    INT,
    @area  DECIMAL(10, 2),
    @setor INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Stand WHERE id_stand = @id)
        UPDATE dbo.Stand SET area_m2 = @area, id_setor = @setor WHERE id_stand = @id
    ELSE
        INSERT INTO dbo.Stand (id_stand, area_m2, id_setor) VALUES (@id, @area, @setor)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarStand
    @id INT
AS
BEGIN
    DELETE FROM dbo.Stand WHERE id_stand = @id
END
GO

-- ── Tipo de Acesso ──────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarTipoAcesso
    @id   INT,
    @nome VARCHAR(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Tipo_de_Acesso WHERE id_tipo = @id)
        UPDATE dbo.Tipo_de_Acesso SET nome_perfil = @nome WHERE id_tipo = @id
    ELSE
        INSERT INTO dbo.Tipo_de_Acesso (id_tipo, nome_perfil) VALUES (@id, @nome)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarTipoAcesso
    @id INT
AS
BEGIN
    DELETE FROM dbo.Tipo_de_Acesso WHERE id_tipo = @id
END
GO

-- ── Token ───────────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarToken
    @id INT,
    @qr VARCHAR(255),
    @st VARCHAR(50),
    @tp INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Token WHERE id_token = @id)
        UPDATE dbo.Token SET codigo_qr = @qr, status = @st, id_tipo = @tp WHERE id_token = @id
    ELSE
        INSERT INTO dbo.Token (id_token, codigo_qr, status, id_tipo) VALUES (@id, @qr, @st, @tp)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarToken
    @id INT
AS
BEGIN
    DELETE FROM dbo.Token WHERE id_token = @id
END
GO

-- ── Ponto de Acesso ─────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarPontoAcesso
    @id    INT,
    @d     VARCHAR(255),
    @s     VARCHAR(50),
    @setor INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Ponto_de_Acesso WHERE id_ponto_de_acesso = @id)
        UPDATE dbo.Ponto_de_Acesso
        SET designacao = @d, sentido = @s, id_setor = @setor
        WHERE id_ponto_de_acesso = @id
    ELSE
        INSERT INTO dbo.Ponto_de_Acesso (id_ponto_de_acesso, designacao, sentido, id_setor)
        VALUES (@id, @d, @s, @setor)
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarPontoAcesso
    @id INT
AS
BEGIN
    DELETE FROM dbo.Ponto_de_Acesso WHERE id_ponto_de_acesso = @id
END
GO

-- ── Participante ────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_GuardarParticipante
    @id   INT,
    @nif  VARCHAR(20),
    @nome VARCHAR(255),
    @tel  VARCHAR(20),
    @ev   INT,
    @tipo VARCHAR(20),
    @emp  VARCHAR(255),
    @stand INT,
    @prof VARCHAR(255)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM dbo.Participante WHERE id_participante = @id)
            UPDATE dbo.Participante
            SET nif = @nif, nome_completo = @nome, telemovel = @tel, id_evento = @ev
            WHERE id_participante = @id
        ELSE
            INSERT INTO dbo.Participante (id_participante, nif, nome_completo, telemovel, id_evento)
            VALUES (@id, @nif, @nome, @tel, @ev)

        DELETE FROM dbo.Expositor WHERE id_participante = @id
        DELETE FROM dbo.Visitante  WHERE id_participante = @id

        IF @tipo = 'Expositor'
            INSERT INTO dbo.Expositor (id_participante, nome_empresa, id_stand, data_inicio_ocupacao)
            VALUES (@id, @emp, NULLIF(@stand, 0), GETDATE())
        ELSE
            INSERT INTO dbo.Visitante (id_participante, profissao)
            VALUES (@id, @prof)

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarParticipante
    @id INT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM dbo.Expositor   WHERE id_participante = @id
        DELETE FROM dbo.Visitante   WHERE id_participante = @id
        DELETE FROM dbo.Participante WHERE id_participante = @id
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- ── Validação ───────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_ValidarToken
    @qr       VARCHAR(255),
    @id_ponto INT,
    @singleUse BIT
AS
BEGIN
    DECLARE @idToken  INT
    DECLARE @status   VARCHAR(50)
    DECLARE @resultado VARCHAR(100)

    SELECT @idToken = id_token, @status = status
    FROM dbo.Token
    WHERE codigo_qr = @qr

    IF @idToken IS NULL
    BEGIN
        SET @resultado = 'Negado - Token desconhecido'
        SELECT @resultado AS resultado
        RETURN
    END

    IF @status != 'Ativo'
        SET @resultado = 'Negado - Status: ' + @status
    ELSE
        SET @resultado = 'Permitido'

    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @idVal INT = (SELECT ISNULL(MAX(id_validacao), 0) + 1 FROM dbo.Validacao)

        INSERT INTO dbo.Validacao (id_validacao, codigo_lido, resultado, id_ponto_de_acesso, id_token)
        VALUES (@idVal, @qr, @resultado, @id_ponto, @idToken)

        IF @resultado = 'Permitido' AND @singleUse = 1
            UPDATE dbo.Token SET status = 'Usado' WHERE id_token = @idToken

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH

    SELECT @resultado AS resultado
END
GO

-- ── Venda ───────────────────────────────────────────────────

CREATE OR ALTER PROCEDURE dbo.sp_RegistarVenda
    @email   VARCHAR(255),
    @id_tipo INT,
    @preco   DECIMAL(10, 2),
    @validade DATE,
    @id_part INT,
    @metodo  VARCHAR(100),
    @ref     VARCHAR(255)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @idUtilizador INT
        SELECT @idUtilizador = id_utilizador FROM dbo.Utilizador WHERE email = @email
        IF @idUtilizador IS NULL
        BEGIN
            RAISERROR('Utilizador da sessão não encontrado.', 16, 1)
            RETURN
        END

        DECLARE @idVenda INT = (SELECT ISNULL(MAX(id_venda),     0) + 1 FROM dbo.Venda)
        DECLARE @idToken INT = (SELECT ISNULL(MAX(id_token),     0) + 1 FROM dbo.Token)
        DECLARE @idPag   INT = (SELECT ISNULL(MAX(id_pagamento), 0) + 1 FROM dbo.Pagamento)
        DECLARE @qr VARCHAR(255) = 'QR-' + UPPER(LEFT(REPLACE(CAST(NEWID() AS VARCHAR(36)), '-', ''), 12))

        INSERT INTO dbo.Venda (id_venda, data_emissao, valor_total, id_utilizador)
        VALUES (@idVenda, GETDATE(), @preco, @idUtilizador)

        INSERT INTO dbo.Token (id_token, codigo_qr, status, id_tipo)
        VALUES (@idToken, @qr, 'Ativo', @id_tipo)

        INSERT INTO dbo.Ingresso (id_token, preco_pago, data_validade, id_venda, id_participante)
        VALUES (@idToken, @preco, @validade, @idVenda, @id_part)

        INSERT INTO dbo.Pagamento (id_pagamento, metodo, referencia, valor, id_venda)
        VALUES (@idPag, @metodo, NULLIF(@ref, ''), @preco, @idVenda)

        COMMIT
        SELECT @idVenda AS id_venda, @qr AS codigo_qr
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO


-- ── Participantes e Venda ───────────────────────────────────────────────────

CREATE PROCEDURE dbo.sp_CriarParticipanteEVenda
    -- dados do participante
    @id_part INT,
    @nif     VARCHAR(20),
    @nome    VARCHAR(255),
    @tel     VARCHAR(20),
    @id_evento INT,
    @tipo    VARCHAR(20),
    @emp     VARCHAR(255),
    @stand   INT,
    @prof    VARCHAR(255),
    -- dados da venda
    @email_utilizador VARCHAR(255),
    @id_tipo_acesso   INT,
    @preco            DECIMAL(10, 2),
    @validade         DATE,
    @metodo           VARCHAR(100),
    @ref              VARCHAR(255)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        EXEC dbo.sp_GuardarParticipante
            @id_part, @nif, @nome, @tel, @id_evento,
            @tipo, @emp, @stand, @prof

        EXEC dbo.sp_RegistarVenda
            @email_utilizador, @id_tipo_acesso, @preco,
            @validade, @id_part, @metodo, @ref

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END

-- ──FUNÇÕOES ───────────────────────────────────────────────────

CREATE FUNCTION dbo.fn_TotalVendasParticipante (@id_part INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN (
        SELECT ISNULL(SUM(preco_pago), 0)
        FROM dbo.Ingresso
        WHERE id_participante = @id_part
    )
END

CREATE FUNCTION dbo.fn_TotalIngressosEvento (@id_evento INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM dbo.Ingresso i
        INNER JOIN dbo.Participante p ON p.id_participante = i.id_participante
        WHERE p.id_evento = @id_evento
    )
END