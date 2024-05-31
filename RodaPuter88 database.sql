drop database if exists db_rodaputar88;
create database db_rodaputar88;
use db_rodaputar88;

create table `produk`(
ID_Produk int unsigned auto_increment,
namaproduk varchar(100) not null,
costproduksi double not null,
Harga_jual int unsigned,
stock int,
tanggalproduksi timestamp not null default current_timestamp,
primary key (ID_Produk)
);

insert into `produk`(namaproduk, costproduksi, Harga_jual, stock)
values
("Kopi Latte", 10000, 25000, 20),
("Pouch Bubuk", 15000, 25000, 20),
("Celup Dukuh", 15000, 35000, 20);

create table `BahanMentahGudang`(
ID_BahanMentah int unsigned auto_increment,
namaBahan varchar(100) not null,
StockBahanMentah int,
primary key (ID_BahanMentah)
);

insert into `BahanMentahGudang`(namaBahan, StockBahanMentah)
values
("Biji kopi", 120),
("Pouch", 60),
("Box", 60),
("Cup", 60);

create table `login`(
ID_user int unsigned auto_increment,
nama varchar(100) not null,
userpass varchar(100) not null,
alamat varchar(100) ,
email varchar(100) not null,
nomortelpon varchar(100) ,
primary key(ID_user)
);

insert into `login`(nama, userpass , alamat, email, nomortelpon)
values
("Jason Christopher", "sdfasd", "Citraland 7/10", "Jchristopher@gmail.com", "08813208138"),
("Kenneith Wijaya","123123" , "Citraland 9/11", "Kwijayar@gmail.com", "0431444525"),
("Rangga Rijasa", "asd22323", "Citraland 12/12", "Rrijasar@gmail.com", "0432424242");

insert into `login`(nama, userpass , alamat, email, nomortelpon)
values
("user", "0000", "Citraland 7/10", "userr@gmail.com", "08813208138");

create table `transaksi`(
	Transaksi_id int unsigned not null auto_increment,
	User_id int unsigned,
    Tanggal_transaksi date,
    Total_harga int,
    Type_pembelian varchar(100),
    foreign key (User_id) references `login`(ID_user),
	Primary Key (Transaksi_id)
);

insert into `transaksi` (User_id, Tanggal_transaksi, Total_harga, Type_pembelian)
values
((SELECT ID_user FROM `login` WHERE nama = 'Jason Christopher'), "2023-10-24", 50000, "Transfer"),
((SELECT ID_user FROM `login` WHERE nama = 'Kenneith Wijaya'), "2023-10-24", 50000, "Cash"),
((SELECT ID_user FROM `login` WHERE nama = 'Rangga Rijasa'), "2023-10-24", 35000, "Qris"),
((SELECT ID_user FROM `login` WHERE nama = 'Kenneith Wijaya'), "2023-10-24", 35000, "Cash"),
((SELECT ID_user FROM `login` WHERE nama = 'Rangga Rijasa'), "2023-12-25", 60000, "Qris"),
((SELECT ID_user FROM `login` WHERE nama = 'Rangga Rijasa'), "2023-12-26", 70000, "Qris"),
((SELECT ID_user FROM `login` WHERE nama = 'Jason Christopher'), "2023-12-26", 35000, "Transfer"),
((SELECT ID_user FROM `login` WHERE nama = 'Kenneith Wijaya'), "2023-12-27", 35000, "Transfer"),
((SELECT ID_user FROM `login` WHERE nama = 'Jason Christopher'), "2023-12-28", 35000, "Transfer");

create table `detail transaksi`(
    Transaksi_id int unsigned,
    Produk_id int unsigned,
    Harga_satuan int unsigned,
    foreign key (Transaksi_id) references `transaksi`(Transaksi_id),
    foreign key (Produk_id) references `produk`(ID_Produk)
);

insert into `detail transaksi` (Transaksi_id, Produk_id, Harga_satuan)
values
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 1), (SELECT ID_Produk FROM produk WHERE namaproduk = "Kopi Latte"), 25000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 1), (SELECT ID_Produk FROM produk WHERE namaproduk = "Kopi Latte"), 25000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 2), (SELECT ID_Produk FROM produk WHERE namaproduk = "Pouch Bubuk"), 25000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 2), (SELECT ID_Produk FROM produk WHERE namaproduk = "Pouch Bubuk"), 25000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 3), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 4), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 5), (SELECT ID_Produk FROM produk WHERE namaproduk = "Pouch Bubuk"), 25000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 5), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 6), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 6), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 7), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 8), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000),
((SELECT Transaksi_id FROM transaksi WHERE Transaksi_id = 9), (SELECT ID_Produk FROM produk WHERE namaproduk = "Celup Dukuh"), 35000);

create table `PembelianBahanMentah`(
ID_BeliBahan int unsigned auto_increment,
namabahan varchar(500),
hargabeli double not null, 
stock int unsigned,
tanggalproduksi date,
PembelianatauPengunaan varchar(50),
constraint orderorused check (PembelianatauPengunaan = "Available" or PembelianatauPengunaan = "Used"),
primary key (ID_BeliBahan)
);

insert into `PembelianBahanMentah`(namabahan, hargabeli, stock, tanggalproduksi, PembelianatauPengunaan)
values
("Biji kopi", 100000,60,"2023-12-28","Available"),
("Biji kopi",100000,60,"2023-12-28","Available"),
("Pouch",20000,60,"2023-12-28","Available"),
("Box",10000,60,"2023-12-28","Available"),
("Cup",10000,60,"2023-12-28","Available"),
("Biji Kopi",34000,20,"2023-12-27","Used");

create table `StokOpname`(
ID_Opnam int unsigned auto_increment,
Username varchar(100), 
JenisBarang varchar(100),
TanggalWaktu_opnam varchar(1000),
Stok_system int unsigned,
Stok_real int unsigned,
Diff int unsigned,
Keterangan varchar(999) ,
primary key (ID_Opnam)
);

insert into `StokOpname` (Username,JenisBarang, TanggalWaktu_opnam, Stok_system, Stok_real, Diff, keterangan)
values
("testdata","Biji kopi", "12/3/2023", 45, 40, 5, "ada barang rusak");

drop function if exists fperproduksold;
delimiter //
create function fperproduksold(tipeproduk varchar(30))
returns int
deterministic
begin

declare totalsold int;

select count(Produk_id) into totalsold
from `detail transaksi` d,produk p
where p.namaproduk=tipeproduk and d.Produk_id=p.ID_produk;

return totalsold;
end //
delimiter ;

select fperproduksold("Pouch Bubuk");

drop function if exists totalharga;
delimiter //
create function totalharga(typetransaksi int,idproduk int)
returns int
deterministic
begin

declare totalharga int;

select sum(d.Harga_satuan) into totalharga
from `detail transaksi` d
where d.Transaksi_id=typetransaksi and d.Produk_id=idproduk;


return totalharga;
end//
delimiter ;

select totalharga(5,2);

drop procedure if exists pstockkurangi;
delimiter //
create procedure pstockkurangi(inout stockkurangi int,in kodeproduk varchar(10))
begin
declare stockproduk int;
select stock into stockproduk
from produk 
where ID_Produk=kodeproduk;
set stockkurangi = stockproduk-stockkurangi;
end//
delimiter ;

set @kurangi = 10;
call pstockkurangi(@kurangi,1);
select @kurangi;

drop procedure if exists pstockbahanmentah;
delimiter //
create procedure pstockbahanmentah(in tambahbahanmentah int,in kodebahan varchar(10),out stockakhir int )
begin
declare stockmentah int;
select stock into stockmentah
from pembelianbahanmentah
where ID_BeliBahan=kodebahan ;
set stockakhir = stockmentah+tambahbahanmentah;
end //
delimiter ;

set @stockakhir = 0;
call pstockbahanmentah(10,2,@stockakhir);
select @stockakhir;


CREATE VIEW TotalSales AS
SELECT
    t.Transaksi_id AS TransactionID,
    l.nama AS UserName,
    t.Tanggal_transaksi AS TransactionDate,
    SUM(dt.Harga_satuan) AS TotalHarga
FROM
    transaksi t
JOIN
    login l ON t.User_id = l.ID_user
JOIN
    `detail transaksi` dt ON t.Transaksi_id = dt.Transaksi_id
GROUP BY
    t.Transaksi_id, l.nama, t.Tanggal_transaksi;
    
    
CREATE VIEW LowStock AS
SELECT
    p.ID_Produk AS ProductID,
    p.namaproduk AS ProductName,
    p.stock AS StockLevel
FROM
    `produk` p
WHERE
    p.stock < 10;
    
CREATE VIEW Invoice AS
SELECT
    t.Transaksi_id AS InvoiceID,
    l.nama AS UserName,
    l.alamat AS UserAddress,
    l.email AS UserEmail,
    l.nomortelpon AS UserPhone,
    t.Tanggal_transaksi AS TransactionDate,
    t.Type_pembelian AS PurchaseType,
    p.namaproduk AS ProductName,
    SUM(dt.Harga_satuan) AS TotalPrice
FROM
    `transaksi` t
JOIN
    `login` l ON t.User_id = l.ID_user
JOIN
    `detail transaksi` dt ON t.Transaksi_id = dt.Transaksi_id
JOIN
    `produk` p ON dt.Produk_id = p.ID_Produk
GROUP BY
    InvoiceID, UserName, UserAddress, UserEmail, UserPhone, TransactionDate, PurchaseType, ProductName;

CREATE VIEW ProductCost AS
SELECT
    ID_Produk AS ProductID,
    namaproduk AS ProductName,
    costproduksi AS CostPrice
FROM
    produk;

select * from TotalSales;
select * from LowStock;
select * from Invoice;
select * from ProductCost;




