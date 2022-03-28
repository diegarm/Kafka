USE [Teste]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*CRIAR A TABELA OUTBOX*/
CREATE TABLE [dbo].[Outbox](
	[id] [uniqueidentifier] NOT NULL, --É o valor do header, pode ser utilizado para remover mensagens duplicadas
	[aggregatetype] [varchar](255) NOT NULL, --Nome do Tópico baseado na variavel ${routedByValue}
	[aggregateid] [varchar](255) NOT NULL, --Contém a chave do evento, a chave emitida pelo evento (da entidade), isso é utilizado para manter a ordem nas partiçoes do Kafka
	[eventType] [varchar](255) NOT NULL, --Tipo do Evento
	[payload] NVARCHAR(MAX) NOT NULL, --Representa a mensagem, por padrão é JSON, mas podemos alterar (se atente no tipo da coluna)
	[created] [datetime] NOT NULL,
 CONSTRAINT [PK_Outbox] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*
SMT - Single message transformation
*/


/*HABILITAR O CDC*/
exec sys.sp_cdc_enable_db


/*CRIA O CDC*/
exec sys.sp_cdc_enable_table
@source_schema = N'dbo',
@source_name = N'Outbox',
@role_name = N'Admin'