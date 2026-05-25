/* ============================================================
   RESET COMPLETO + Seed data para a BD p4g5
   ATENÇÃO: este script APAGA todos os dados existentes!
   Corre no SSMS quando quiseres começar de zero.
   ============================================================ */

USE p4g5;
GO

/* ----------------- APAGAR TUDO (ordem inversa de FKs) ------- */
DELETE FROM dbo.Validacao;
DELETE FROM dbo.Pagamento;
DELETE FROM dbo.Ingresso;
DELETE FROM dbo.Credencial;
DELETE FROM dbo.Venda;
DELETE FROM dbo.permite;
DELETE FROM dbo.Token;
DELETE FROM dbo.Expositor;
DELETE FROM dbo.Visitante;
DELETE FROM dbo.Participante;
DELETE FROM dbo.Stand;
DELETE FROM dbo.Ponto_de_Acesso;
DELETE FROM dbo.Setor;
DELETE FROM dbo.Tipo_de_Acesso;
DELETE FROM dbo.Evento;
DELETE FROM dbo.Utilizador;
GO

PRINT 'Tabelas limpas. A inserir dados de teste...';
GO

/* ----------------- 1) Utilizadores -------------------------- */
INSERT INTO dbo.Utilizador(id_utilizador, email, password_hash) VALUES
(1, 'admin@ua.pt',   'admin'),
(2, 'duarte@ua.pt',  '1234'),
(3, 'maria@ua.pt',   'maria123');
GO

/* ----------------- 2) Eventos ------------------------------- */
INSERT INTO dbo.Evento(id_evento, nome, data_inicio, data_fim) VALUES
(1, 'TechFair 2026',       '2026-06-10', '2026-06-12'),
(2, 'FoodExpo Aveiro',     '2026-07-15', '2026-07-17'),
(3, 'Auto Show Portugal',  '2026-09-01', '2026-09-05');
GO

/* ----------------- 3) Setores ------------------------------- */
INSERT INTO dbo.Setor(id_setor, id_evento) VALUES
(1, 1), (2, 1), (3, 2), (4, 2), (5, 3);
GO

/* ----------------- 4) Stands -------------------------------- */
INSERT INTO dbo.Stand(id_stand, area_m2, id_setor) VALUES
(1, 25.50, 1),
(2, 40.00, 1),
(3, 30.00, 2),
(4, 15.75, 3),
(5, 20.00, 4),
(6, 100.00, 5);
GO

/* ----------------- 5) Tipos de Acesso ----------------------- */
INSERT INTO dbo.Tipo_de_Acesso(id_tipo, nome_perfil) VALUES
(1, 'Geral'),
(2, 'VIP'),
(3, 'Expositor'),
(4, 'Imprensa');
GO

/* ----------------- 6) Pontos de Acesso ---------------------- */
INSERT INTO dbo.Ponto_de_Acesso(id_ponto_de_acesso, designacao, sentido, id_setor) VALUES
(1, 'Entrada Principal',  'Entrada', 1),
(2, 'Saida Principal',    'Saida',   1),
(3, 'Entrada Setor B',    'Entrada', 2),
(4, 'Entrada FoodExpo',   'Entrada', 3),
(5, 'Entrada AutoShow',   'Entrada', 5);
GO

/* ----------------- 7) Relacao permite ----------------------- */
INSERT INTO dbo.permite(id_tipo, id_setor) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
(2, 1), (2, 2), (2, 3), (2, 4), (2, 5),
(3, 1), (3, 2),
(4, 1), (4, 2), (4, 3), (4, 4), (4, 5);
GO

/* ----------------- 8) Participantes ------------------------- */
INSERT INTO dbo.Participante(id_participante, nif, nome_completo, telemovel, id_evento) VALUES
(1, '111111111', 'Joao Silva',       '912345678', 1),
(2, '222222222', 'Ana Costa',        '913456789', 1),
(3, '333333333', 'Pedro Santos',     '914567890', 1),
(4, '444444444', 'Mariana Ferreira', '915678901', 2),
(5, '555555555', 'Rui Pereira',      '916789012', 2),
(6, '666666666', 'Sofia Almeida',    '917890123', 3);
GO

/* ----------------- 9) Expositor ----------------------------- */
INSERT INTO dbo.Expositor(id_participante, id_expositor, nome_empresa, id_stand, data_inicio_ocupacao) VALUES
(1, 'EXP001', 'TechCorp Lda',  1, '2026-06-09'),
(4, 'EXP002', 'DocesAna Lda',  4, '2026-07-14');
GO

/* ----------------- 10) Visitante ---------------------------- */
INSERT INTO dbo.Visitante(id_participante, profissao) VALUES
(2, 'Estudante'),
(3, 'Engenheiro'),
(5, 'Chef'),
(6, 'Mecanico');
GO

/* ----------------- 11) Tokens ------------------------------- */
INSERT INTO dbo.Token(id_token, codigo_qr, status, id_tipo) VALUES
(1, 'QR-ABC123456789', 'Ativo', 1),
(2, 'QR-DEF234567890', 'Ativo', 1),
(3, 'QR-GHI345678901', 'Ativo', 2),
(4, 'QR-JKL456789012', 'Usado', 1),
(5, 'QR-MNO567890123', 'Ativo', 3),
(6, 'QR-PQR678901234', 'Ativo', 4);
GO

/* ----------------- 12) Credenciais -------------------------- */
INSERT INTO dbo.Credencial(id_token, cargo_no_cartao, data_validade, id_participante) VALUES
(5, 'CEO TechCorp', '2026-06-12', 1),
(6, 'Jornalista',   '2026-06-12', 3);
GO

/* ----------------- 13) Vendas ------------------------------- */
INSERT INTO dbo.Venda(id_venda, data_emissao, valor_total, id_utilizador) VALUES
(1, '2026-06-08', 15.00, 1),
(2, '2026-06-09', 50.00, 1),
(3, '2026-07-10', 10.00, 2);
GO

/* ----------------- 14) Ingressos ---------------------------- */
INSERT INTO dbo.Ingresso(id_token, preco_pago, data_validade, id_venda, id_participante) VALUES
(1, 15.00, '2026-06-12', 1, 2),
(2, 15.00, '2026-06-12', 1, 3),
(3, 50.00, '2026-06-12', 2, 2),
(4, 10.00, '2026-07-17', 3, 5);
GO

/* ----------------- 15) Pagamentos --------------------------- */
INSERT INTO dbo.Pagamento(id_pagamento, metodo, referencia, valor, id_venda) VALUES
(1, 'Multibanco',         'REF-001-2026', 15.00, 1),
(2, 'Cartao de Credito',  'CC-VISA-9999', 50.00, 2),
(3, 'MBWay',              '912345678',    10.00, 3);
GO

PRINT 'Seed completo!';
GO

/* ----------------- Verificacao ------------------------------ */
SELECT 'Utilizador'      AS tabela, COUNT(*) AS total FROM dbo.Utilizador
UNION ALL SELECT 'Evento',          COUNT(*) FROM dbo.Evento
UNION ALL SELECT 'Setor',           COUNT(*) FROM dbo.Setor
UNION ALL SELECT 'Stand',           COUNT(*) FROM dbo.Stand
UNION ALL SELECT 'Tipo_de_Acesso',  COUNT(*) FROM dbo.Tipo_de_Acesso
UNION ALL SELECT 'Ponto_de_Acesso', COUNT(*) FROM dbo.Ponto_de_Acesso
UNION ALL SELECT 'Participante',    COUNT(*) FROM dbo.Participante
UNION ALL SELECT 'Expositor',       COUNT(*) FROM dbo.Expositor
UNION ALL SELECT 'Visitante',       COUNT(*) FROM dbo.Visitante
UNION ALL SELECT 'Token',           COUNT(*) FROM dbo.Token
UNION ALL SELECT 'Credencial',      COUNT(*) FROM dbo.Credencial
UNION ALL SELECT 'Venda',           COUNT(*) FROM dbo.Venda
UNION ALL SELECT 'Ingresso',        COUNT(*) FROM dbo.Ingresso
UNION ALL SELECT 'Pagamento',       COUNT(*) FROM dbo.Pagamento
UNION ALL SELECT 'permite',         COUNT(*) FROM dbo.permite;
