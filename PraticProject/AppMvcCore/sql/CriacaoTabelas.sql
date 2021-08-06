IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [t_fornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [nome] varchar(200) NOT NULL,
    [documento] varchar(14) NOT NULL,
    [ativo] bit NOT NULL,
    [TipoFornecedor] int NOT NULL,
    CONSTRAINT [PK_t_fornecedor] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [t_endereco] (
    [Id] uniqueidentifier NOT NULL,
    [estado] varchar(50) NOT NULL,
    [cidade] varchar(100) NOT NULL,
    [logradouro] varchar(200) NOT NULL,
    [complemento] varchar(250) NOT NULL,
    [cep] varchar(8) NOT NULL,
    [bairro] varchar(200) NOT NULL,
    [numero] varchar(50) NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_t_endereco] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_t_endereco_t_fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [t_fornecedor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [t_produto] (
    [Id] uniqueidentifier NOT NULL,
    [nome] varchar(200) NOT NULL,
    [descricao] varchar(1000) NOT NULL,
    [imagem] varchar(100) NOT NULL,
    [valor] decimal(5,2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [ativo] bit NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_t_produto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_t_produto_t_fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [t_fornecedor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_t_endereco_FornecedorId] ON [t_endereco] ([FornecedorId]);

GO

CREATE INDEX [IX_t_produto_FornecedorId] ON [t_produto] ([FornecedorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210806191509_Initial', N'3.1.14');

GO

