DROP TABLE TB_M_MENU;
CREATE TABLE TB_M_MENU(
	Id UNIQUEIDENTIFIER NOT NULL,
	ParentId uniqueidentifier NULL,
	Title varchar(50) not null,
	Url varchar(50) not null,
	Description varchar(300) not null,
	
	IconClass varchar(50) not null,
	OrderIndex int not null,
	Visible bit not null,
	FunctionId varchar(50) not null,
	Section varchar(50) not null,

	CreatedAt DATETIME NOT NULL,
	CreatedBy VARCHAR(50) NOT NULL,
	UpdatedAt DATETIME NULL,
	UpdatedBy VARCHAR(50) NOT NULL,
	
	PRIMARY KEY(Id),
	index tb_m_menu_functionId_index nonclustered (functionId)
);
insert into tb_m_menu values('20CF2630-37D7-4F47-974A-6DC91C6A65CA', null, 'Bookings', '~/Transaction/Bookings', 'Bookings', 'pe-7s-note2', 1, 1, '', getdate(), 'System', null, '');
insert into tb_m_menu values('E0E006AA-0F29-4B95-89B6-95C2799A2FAB', null, 'Master', '', 'Master', 'pe-7s-notebook', 2, 1, '', getdate(), 'System', null, '');
insert into tb_m_menu values('60A40743-F4F9-4D2F-8647-A0E77A626933', null, 'Configuration', '', 'Configuration', 'pe-7s-config', 5, 1, '', getdate(), 'System', null, '');
insert into tb_m_menu values('4705448D-FF73-4764-BC02-42F44BFF3849', null, 'MyProfile', '', 'MyProfile', 'pe-7s-user', 10, 1, '', getdate(), 'System', null, '');

insert into tb_m_menu values(newid(), 'E0E006AA-0F29-4B95-89B6-95C2799A2FAB', 'Products', '~/Transaction/Products', 'Products', 'pe-7s-notebook', 3, 1, 'Product.View', getdate(), 'System', null, '');
insert into tb_m_menu values(newid(), 'E0E006AA-0F29-4B95-89B6-95C2799A2FAB', 'Categories', '~/Transaction/Categories', 'Categories', 'pe-7s-notebook', 4, 1, 'Category.View', getdate(), 'System', null, '');

insert into tb_m_menu values(newid(), '60A40743-F4F9-4D2F-8647-A0E77A626933', 'Users', '~/Transaction/Users', 'Users', 'pe-7s-config', 6, 1, 'Users.View', getdate(), 'System', null, '');
insert into tb_m_menu values(newid(), '60A40743-F4F9-4D2F-8647-A0E77A626933', 'Roles', '~/Transaction/Roles', 'Roles', 'pe-7s-config', 7, 1, 'Roles.View', getdate(), 'System', null, '');
insert into tb_m_menu values(newid(), '60A40743-F4F9-4D2F-8647-A0E77A626933', 'SystemConfiguration', '~/Transaction/SystemConfiguration', 'SystemConfiguration', 'pe-7s-config', 8, 1, 'SystemConfiguration.View', getdate(), 'System', null, '');
insert into tb_m_menu values(newid(), '60A40743-F4F9-4D2F-8647-A0E77A626933', 'SMTPSetting', '~/Transaction/SMTPSetting', 'SMTPSetting', 'pe-7s-config', 9, 1, 'SMTPSetting.View', getdate(), 'System', null, '');


