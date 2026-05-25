# EventoApp — Interface Windows Forms para BD p4g5

Aplicação Windows Forms (C# / .NET Framework 4.8) que serve de frontend à base
de dados `p4g5` (gestão de eventos: participantes, tokens, vendas, validações
de acesso).

## Estrutura

```
Projeto/
├── script.sql                  ← o teu script de criação da BD
├── EventoApp.sln               ← abrir este ficheiro no VS 2022
└── EventoApp/
    ├── App.config              ← connection string (EDITAR!)
    ├── Program.cs              ← entrada da aplicação
    ├── Database/
    │   └── DbHelper.cs         ← acesso a dados (SqlConnection)
    ├── Forms/
    │   ├── LoginForm           ← autenticação contra tabela Utilizador
    │   ├── MainForm            ← MDI com menu principal
    │   ├── EventoForm          ← CRUD Evento
    │   ├── ParticipanteForm    ← CRUD Participante + subtipos
    │   ├── SetorForm           ← CRUD Setor
    │   ├── StandForm           ← CRUD Stand
    │   ├── PontoAcessoForm     ← CRUD Ponto de Acesso
    │   ├── TipoAcessoForm      ← CRUD Tipo de Acesso
    │   ├── TokenForm           ← CRUD Token
    │   ├── VendaForm           ← Venda completa (Venda + Token + Ingresso + Pagamento)
    │   └── ValidacaoForm       ← Simulação de leitura de QR
    └── Properties/
        └── AssemblyInfo.cs
```

## Como abrir / executar

1. Executar o `script.sql` no SQL Server Management Studio (cria a BD `p4g5`).
2. **Editar `EventoApp/App.config`** e ajustar `Data Source` ao teu servidor:
   - `.\SQL_UA_BD` se estás na máquina virtual da UA
   - `.\SQLEXPRESS` se tens SQL Express local
   - `localhost,1433` ou IP\instância para servidor remoto
3. Abrir `EventoApp.sln` no Visual Studio 2022.
4. F5 para correr.

## Antes do primeiro login

A tabela `Utilizador` está vazia depois do script. Insere pelo menos um
utilizador (atenção: a coluna `password_hash` armazena a password — para
simplicidade académica não há hashing real):

```sql
USE p4g5;
INSERT INTO dbo.Utilizador(id_utilizador, email, password_hash)
VALUES (1, 'admin@ua.pt', 'admin');
```

Depois faz login com `admin@ua.pt` / `admin`.

## Operações típicas

1. **Cadastros → Eventos** — cria um evento.
2. **Cadastros → Setores** — adiciona setores ao evento.
3. **Cadastros → Stands** — cria stands em cada setor.
4. **Cadastros → Tipos de Acesso** — define perfis (ex.: "Geral", "VIP",
   "Expositor").
5. **Cadastros → Pontos de Acesso** — entradas/saídas associadas a setores.
6. **Cadastros → Participantes** — regista pessoas (visitante ou expositor).
7. **Operações → Venda de Ingressos** — uma só ação cria Venda + Token +
   Ingresso + Pagamento (numa transação).
8. **Operações → Validação de Acesso** — cola o `codigo_qr` (visível na lista
   da Venda ou em Tokens), escolhe ponto e clica Validar.

## Notas técnicas

- As PKs no script não são `IDENTITY`. A app calcula sempre o próximo ID com
  `MAX(id)+1`. Em produção isto não é seguro com concorrência; numa cadeira
  de BD académica é aceitável.
- `Validacao.data_hora` está como `timestamp` no script — em SQL Server isto
  é `rowversion` (não é uma data!). A app não insere essa coluna; o servidor
  preenche-a automaticamente. Se quiseres datas/horas reais, altera o tipo
  da coluna para `datetime2` no script.
- O Login compara `password_hash` em texto simples. Para fazeres hashing real
  (recomendado), aplica `SHA256` em código antes de inserir e antes de
  comparar.

## Customização rápida

Para adicionar uma nova tabela como form CRUD:

1. Duplica `EventoForm.cs` + `EventoForm.Designer.cs`.
2. Renomeia classe e nomes de controlos.
3. Ajusta as queries SQL e nomes de colunas.
4. Adiciona a entrada no `MainForm` (menu + handler).
5. Adiciona os dois ficheiros no `.csproj`.

Bom trabalho!
