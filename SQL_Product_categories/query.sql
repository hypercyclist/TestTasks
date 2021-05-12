create table goods ( 
    id int primary key, 
    name varchar(100)
    );
  
create table category (
    id int primary key, 
    category_name varchar(100),
    goods_name varchar(100)
    );
    
insert into category (id, goods_name, category_name) values (1, "Помидор", "Овощи");
insert into category (id, goods_name, category_name) values (2, "Помидор", "Распродажа");

insert into category (id, goods_name, category_name) values (3, "Огурец", "Овощи");
insert into category (id, goods_name, category_name) values (4, "Огурец", "Распродажа");

insert into category (id, goods_name, category_name) values (5, "Свекла", "Овощи");
insert into category (id, goods_name, category_name) values (6, "Свекла", "Распродажа");

insert into category (id, goods_name, category_name) values (7, "Свинина", "Мясо");
insert into category (id, goods_name, category_name) values (8, "Свинина", "Домашнее");

insert into category (id, goods_name, category_name) values (9, "Курица", "Мясо");
insert into category (id, goods_name, category_name) values (10, "Курица", "Птица");
insert into category (id, goods_name, category_name) values (11, "Курица", "Домашнее");

insert into category (id, goods_name, category_name) values (12, "Говядина", "Мясо");
insert into category (id, goods_name, category_name) values (13, "Говядина", "Домашнее");

insert into category (id, goods_name, category_name) values (14, "Пончики", "Выпечка");
insert into category (id, goods_name, category_name) values (15, "Пончики", "Сладкое");

insert into category (id, goods_name, category_name) values (16, "Фаготини", "Выпечка");
insert into category (id, goods_name, category_name) values (17, "Фаготини", "Слоеное тесто");

insert into category (id, goods_name, category_name) values (18, "Пирожки", "Выпечка");
insert into category (id, goods_name, category_name) values (19, "Пирожки", "Постное");

insert into goods (id, name) values (1, "Помидор");
insert into goods (id, name) values (2, "Огурец");
insert into goods (id, name) values (3, "Свекла");
insert into goods (id, name) values (4, "Свинина");
insert into goods (id, name) values (5, "Курица");
insert into goods (id, name) values (6, "Говядина");
insert into goods (id, name) values (7, "Пончики");
insert into goods (id, name) values (8, "Фаготини");
insert into goods (id, name) values (9, "Пирожки");
insert into goods (id, name) values (10, "Кофе");
insert into goods (id, name) values (11, "Чай");

select distinct name, category_name from goods left join category on goods.name = category.goods_name;

/*
$sqlite3 database.sdb < main.sql
Помидор|Овощи
Помидор|Распродажа
Огурец|Овощи
Огурец|Распродажа
Свекла|Овощи
Свекла|Распродажа
Свинина|Домашнее
Свинина|Мясо
Курица|Домашнее
Курица|Мясо
Курица|Птица
Говядина|Домашнее
Говядина|Мясо
Пончики|Выпечка
Пончики|Сладкое
Фаготини|Выпечка
Фаготини|Слоеное тесто
Пирожки|Выпечка
Пирожки|Постное
Кофе|
Чай|
*/