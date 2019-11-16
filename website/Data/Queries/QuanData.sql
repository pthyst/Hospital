-- [Roles] --
INSERT INTO Roles(Name)
VALUES (N'Bệnh nhân'),(N'Bác sĩ'),(N'Dược sĩ'),(N'Quản trị viên');

-- [Faculties] --
INSERT INTO Faculties(Name,Fee)
VALUES (N'Tim mạch can thiệp',1000000),(N'Tim mạch tổng quát',900000),(N'Nhịp tim học',500000),(N'Hồi sức tim mạch',1000000),
(N'Phẫu thuật tim - Lồng ngực mạch máu',2000000),(N'Nội tiêu hóa',100000),(N'Nội thần kinh tổng quát',200000),(N'Ngoại thần kinh',200000),
(N'Nội tiết',200000),(N'Bệnh ký mạch máu não',500000),(N'Bệnh nhiệt đới',500000),(N'Cơ xương khớp',1000000);

-- [Doctors] --
INSERT INTO Doctors(Role_Id,Faculty_Id,Username,Password,NameFirst,NameMiddle,NameLast,PhoneNumber,Email)
VALUES (2,1,'phamlaprikan','123456lap',N'Lập',N'Gia',N'Phạm','0765991250','phamlap.rikan@gmail.com'),
(2,2,'pthyst','phuongdung',N'Quân',N'Chí',N'Huỳnh Trương','0765991251','pthyst@gmail.com'),
(2,3,'khaicq64','123456khai',N'Khải',N'Quang',N'Cao','0765991252','zcaoquangkhai@gmail.com'),
(2,4,'lspdevilwork','123456hieu',N'Hiếu',N'Trung',N'Đặng','0765991253','devilwork@gmail.com');

-- [Pharamacist] --
INSERT INTO Pharamacists(Role_Id,Username,Password,Email,PhoneNumber,NameLast,NameMiddle,NameFirst,DateCreate,DateModify,DateLastUsed)
VALUES (3,'duocsi1','matkhau123','duocsi1@gmail.com','01265991251',N'Huỳnh',N'Huệ',N'Trang','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(3,'duocsi2','matkhau456','duocsi2@gmail.com','01265991252',N'Phan',N'Huệ',N'Mẩn','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(3,'duocsi3','matkhau789','duocsi3@gmail.com','01265991253',N'Dương',N'Thị Kim',N'Chi','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(3,'duocsi4','matkhau101112','duocsi4@gmail.com','01265991254',N'Khưu',N'Lễ',N'Minh','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(3,'duocsi5','matkhau131415','duocsi5@gmail.com','01265991255',N'Huỳnh',N'Tuyết',N'Trân','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM')

-- [Admins] --
INSERT INTO Admins(Role_Id,Username,Password,Email,PhoneNumber,NameLast,NameMiddle,NameFirst,DateCreate,DateModify,DateLastUsed)
VALUES (4,'richbitch','matkhau123','richbitch@gmail.com','01265991251',N'Trần',N'Ngọc',N'Ánh','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(4,'lustynun','matkhau456','lustynun@gmail.com','01265991252',N'Nguyễn',N'Ái',N'My','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(4,'sajab1109','matkhau789','sajab1109@gmail.com','01265991253',N'Sơn',N'',N'Buôi','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(4,'racingmonk','matkhau101112','racingmonk4@gmail.com','01265991254',N'Thích',N'Độ',N'Xe','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM'),
(4,'pthyst','phuongdung','pthyst@gmail.com','01265991255',N'Huỳnh Trương',N'Chí',N'Quân','20191111 22:00:00 PM','20191111 22:00:00 PM','20191111 22:00:00 PM')

-- [Rooms] --
INSERT INTO Rooms(Name,ShortCode,Faculty_Id)
VALUES (N'Tiếp nhận đăng ký khám chữa bệnh','A100',0),(N'Quản lý BHYT','A101',0),(N'Thủ tục hành chính','A102',0),(N'Dụng cụ sơ cứu','A103',0),
(N'Chụp X Quang','B100',0),(N'Siêu âm - Nội soi','B101',0),(N'Cấp cứu','B102',0);

-- [MedicineUnits] --
INSERT INTO MedicineUnits(Unit) VALUES(N'Lọ'),(N'Chai'),(N'Gam'),(N'Miligam'),(N'Viên'),(N'Viên con nhộng'),(N'Vỉ');

-- [Medicines] --
INSERT INTO Medicines(Name,Price,Instore,MedicineUnit_Id,Admin_Id,DateCreate,DateModify)
VALUES (N'Paracetamol 500mg',1000,10,5,5,'20191114 23:00:00 PM','20191114 23:00:00 PM'),
(N'Tottri',150000,10,2,5,'20191114 23:00:00 PM','20191114 23:00:00 PM')