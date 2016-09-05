select * from [dbo].[User];

CREATE TABLE [dbo].[User] (
  uid int IDENTITY(1,1) NOT NULL,
  firstName nvarchar(45) NOT NULL,
  lastName nvarchar(45) NOT NULL,
  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

insert into [dbo].[User](firstName,lastName) values('FA','LA');
insert into [dbo].[User](firstName,lastName) values('FB','LB');
insert into [dbo].[User](firstName,lastName) values('FC','LC');
insert into [dbo].[User](firstName,lastName) values('FD','LD');