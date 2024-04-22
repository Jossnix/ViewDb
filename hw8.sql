-- CREATE DATABASE hw_db;

-- Создание таблиц
create table if not exists "categories"
(
    "id" uuid not null primary key,
    "name" text
);

create table if not exists "salesman"
(
    "id" uuid not null primary key,
    "name" text,
    "phone" varchar(20)
);

create table if not exists "products"
(
    "id" uuid not null primary key,
    "name" text,
    "category_id" uuid,
    "salesman_id" uuid,
    "sold" bool default false,
    foreign key (category_id) references categories (id),
    foreign key (salesman_id) references salesman (id)
);

-- Заполнение таблиц
INSERT INTO categories (id, name)
values (gen_random_uuid(), 'Транспорт'),
       (gen_random_uuid(), 'Электротехника'),
       (gen_random_uuid(), 'Животные'),
       (gen_random_uuid(), 'Для дома и дачи'),
       (gen_random_uuid(), 'Услуги');

INSERT INTO salesman (id, name, phone)
values (gen_random_uuid(), 'Иванов', '+7-523-456-78-90'),
       (gen_random_uuid(), 'Петров', '+7-623-446-78-92'),
       (gen_random_uuid(), 'Сидоров', '+7-723-436-78-93'),
       (gen_random_uuid(), 'Смирнов', '+7-823-426-78-94'),
       (gen_random_uuid(), 'Сергеев', '+7-923-416-78-95');

INSERT INTO products (id, name, category_id, salesman_id)
values (gen_random_uuid(), 'Велосипед', (select id from categories where "name" = 'Транспорт'), (select id from salesman where "name" = 'Иванов')),
       (gen_random_uuid(), 'Фотовспышка', (select id from categories where "name" = 'Электротехника'), (select id from salesman where "name" = 'Петров')),
       (gen_random_uuid(), 'Овчарка', (select id from categories where "name" = 'Животные'), (select id from salesman where "name" = 'Сидоров')),
       (gen_random_uuid(), 'Мангал', (select id from categories where "name" = 'Для дома и дачи'), (select id from salesman where "name" = 'Смирнов')),
       (gen_random_uuid(), 'Укладка плитки', (select id from categories where "name" = 'Услуги'), (select id from salesman where "name" = 'Сергеев'));
