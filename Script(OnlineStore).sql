--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-12-27 00:36:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4884 (class 1262 OID 25394)
-- Name: OnlineStore; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "OnlineStore" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "OnlineStore" OWNER TO postgres;

\connect "OnlineStore"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4885 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 232 (class 1259 OID 25449)
-- Name: Basket; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Basket" (
    "Id" integer NOT NULL,
    "UserId" integer,
    "ProductId" integer,
    "CountProduct" numeric(18,2),
    "OrderId" integer
);


ALTER TABLE public."Basket" OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 25448)
-- Name: Basket_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Basket_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Basket_Id_seq" OWNER TO postgres;

--
-- TOC entry 4886 (class 0 OID 0)
-- Dependencies: 231
-- Name: Basket_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Basket_Id_seq" OWNED BY public."Basket"."Id";


--
-- TOC entry 226 (class 1259 OID 25426)
-- Name: CategoryProduct; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CategoryProduct" (
    "Id" integer NOT NULL,
    "Name" character varying(100)
);


ALTER TABLE public."CategoryProduct" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 25425)
-- Name: CategoryProduct_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."CategoryProduct_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."CategoryProduct_Id_seq" OWNER TO postgres;

--
-- TOC entry 4887 (class 0 OID 0)
-- Dependencies: 225
-- Name: CategoryProduct_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."CategoryProduct_Id_seq" OWNED BY public."CategoryProduct"."Id";


--
-- TOC entry 224 (class 1259 OID 25419)
-- Name: Order; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Order" (
    "Id" integer NOT NULL,
    "StatusId" integer,
    "Date" timestamp without time zone
);


ALTER TABLE public."Order" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 25418)
-- Name: Order_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Order_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Order_Id_seq" OWNER TO postgres;

--
-- TOC entry 4888 (class 0 OID 0)
-- Dependencies: 223
-- Name: Order_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Order_Id_seq" OWNED BY public."Order"."Id";


--
-- TOC entry 230 (class 1259 OID 25440)
-- Name: Product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Product" (
    "Id" integer NOT NULL,
    "Name" character varying(100),
    "Description" text,
    "Price" numeric(18,2),
    "CategoryId" integer,
    "Image" bytea
);


ALTER TABLE public."Product" OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 25439)
-- Name: Product_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Product_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Product_Id_seq" OWNER TO postgres;

--
-- TOC entry 4889 (class 0 OID 0)
-- Dependencies: 229
-- Name: Product_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Product_Id_seq" OWNED BY public."Product"."Id";


--
-- TOC entry 218 (class 1259 OID 25396)
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    "Id" integer NOT NULL,
    "Name" character varying(100)
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 25395)
-- Name: Role_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Role_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Role_Id_seq" OWNER TO postgres;

--
-- TOC entry 4890 (class 0 OID 0)
-- Dependencies: 217
-- Name: Role_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Role_Id_seq" OWNED BY public."Role"."Id";


--
-- TOC entry 222 (class 1259 OID 25412)
-- Name: Status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Status" (
    "Id" integer NOT NULL,
    "Name" character varying(100)
);


ALTER TABLE public."Status" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 25411)
-- Name: Status_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Status_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Status_Id_seq" OWNER TO postgres;

--
-- TOC entry 4891 (class 0 OID 0)
-- Dependencies: 221
-- Name: Status_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Status_Id_seq" OWNED BY public."Status"."Id";


--
-- TOC entry 234 (class 1259 OID 25456)
-- Name: Storage; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Storage" (
    "Id" integer NOT NULL,
    "ProductId" integer,
    "Count" numeric(18,2)
);


ALTER TABLE public."Storage" OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 25455)
-- Name: Storage_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Storage_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Storage_Id_seq" OWNER TO postgres;

--
-- TOC entry 4892 (class 0 OID 0)
-- Dependencies: 233
-- Name: Storage_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Storage_Id_seq" OWNED BY public."Storage"."Id";


--
-- TOC entry 228 (class 1259 OID 25433)
-- Name: Street; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Street" (
    "Id" integer NOT NULL,
    "Name" character varying(100)
);


ALTER TABLE public."Street" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 25432)
-- Name: Street_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Street_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Street_Id_seq" OWNER TO postgres;

--
-- TOC entry 4893 (class 0 OID 0)
-- Dependencies: 227
-- Name: Street_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Street_Id_seq" OWNED BY public."Street"."Id";


--
-- TOC entry 220 (class 1259 OID 25403)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "Surname" character varying(100),
    "Name" character varying(100),
    "Patronymic" character varying(100),
    "Balance" numeric(18,2),
    "Email" character varying(100),
    "Password" character varying(100),
    "Phone" character varying(12),
    "RoleId" integer,
    "StreetId" integer,
    "House" character varying(50),
    "Apartment" character varying(50)
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 25402)
-- Name: User_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."User_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."User_Id_seq" OWNER TO postgres;

--
-- TOC entry 4894 (class 0 OID 0)
-- Dependencies: 219
-- Name: User_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."User_Id_seq" OWNED BY public."User"."Id";


--
-- TOC entry 4688 (class 2604 OID 25452)
-- Name: Basket Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Basket" ALTER COLUMN "Id" SET DEFAULT nextval('public."Basket_Id_seq"'::regclass);


--
-- TOC entry 4685 (class 2604 OID 25429)
-- Name: CategoryProduct Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CategoryProduct" ALTER COLUMN "Id" SET DEFAULT nextval('public."CategoryProduct_Id_seq"'::regclass);


--
-- TOC entry 4684 (class 2604 OID 25422)
-- Name: Order Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order" ALTER COLUMN "Id" SET DEFAULT nextval('public."Order_Id_seq"'::regclass);


--
-- TOC entry 4687 (class 2604 OID 25443)
-- Name: Product Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product" ALTER COLUMN "Id" SET DEFAULT nextval('public."Product_Id_seq"'::regclass);


--
-- TOC entry 4681 (class 2604 OID 25399)
-- Name: Role Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role" ALTER COLUMN "Id" SET DEFAULT nextval('public."Role_Id_seq"'::regclass);


--
-- TOC entry 4683 (class 2604 OID 25415)
-- Name: Status Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Status" ALTER COLUMN "Id" SET DEFAULT nextval('public."Status_Id_seq"'::regclass);


--
-- TOC entry 4689 (class 2604 OID 25459)
-- Name: Storage Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Storage" ALTER COLUMN "Id" SET DEFAULT nextval('public."Storage_Id_seq"'::regclass);


--
-- TOC entry 4686 (class 2604 OID 25436)
-- Name: Street Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Street" ALTER COLUMN "Id" SET DEFAULT nextval('public."Street_Id_seq"'::regclass);


--
-- TOC entry 4682 (class 2604 OID 25406)
-- Name: User Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User" ALTER COLUMN "Id" SET DEFAULT nextval('public."User_Id_seq"'::regclass);


--
-- TOC entry 4876 (class 0 OID 25449)
-- Dependencies: 232
-- Data for Name: Basket; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (1, 3, 3, 10.00, 2);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (3, 3, 2, 1.00, 3);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (4, 3, 1, 1.00, 4);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (5, 3, 2, 1.00, 4);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (8, 3, 2, 1.00, 5);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (11, 3, 1, 2.00, 6);
INSERT INTO public."Basket" ("Id", "UserId", "ProductId", "CountProduct", "OrderId") VALUES (12, 3, 3, 1.00, 6);


--
-- TOC entry 4870 (class 0 OID 25426)
-- Dependencies: 226
-- Data for Name: CategoryProduct; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."CategoryProduct" ("Id", "Name") VALUES (1, 'Ноутбуки');


--
-- TOC entry 4868 (class 0 OID 25419)
-- Dependencies: 224
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Order" ("Id", "StatusId", "Date") VALUES (2, 3, '2025-10-05 16:15:26');
INSERT INTO public."Order" ("Id", "StatusId", "Date") VALUES (3, 3, '2025-10-05 16:16:26');
INSERT INTO public."Order" ("Id", "StatusId", "Date") VALUES (4, 3, '2025-10-05 16:20:04');
INSERT INTO public."Order" ("Id", "StatusId", "Date") VALUES (5, 3, '2025-10-05 17:41:28');
INSERT INTO public."Order" ("Id", "StatusId", "Date") VALUES (6, 2, '2025-10-06 12:20:03');


--
-- TOC entry 4874 (class 0 OID 25440)
-- Dependencies: 230
-- Data for Name: Product; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Product" ("Id", "Name", "Description", "Price", "CategoryId", "Image") VALUES (1, 'Macbook Air 13', 'Apple MacBook Air 13 2025 M4 256Gb 16Gb (Starlight) Mw0y3', 89999.00, 1, NULL);
INSERT INTO public."Product" ("Id", "Name", "Description", "Price", "CategoryId", "Image") VALUES (2, 'MacBook Pro14', 'Apple MacBook Pro 14 2023 M3/8Gb/512Gb Mr7j3 (Silver)', 117000.00, 1, NULL);
INSERT INTO public."Product" ("Id", "Name", "Description", "Price", "CategoryId", "Image") VALUES (3, 'MacBook Pro 16', 'Apple MacBook Pro 16 Space Black (M4 Pro 14-Core, Gpu 20-Core, 48Gb, 512Gb) Mx2y3', 160000.00, 1, NULL);
INSERT INTO public."Product" ("Id", "Name", "Description", "Price", "CategoryId", "Image") VALUES (23, 'dfges', 'fgres', 98000.00, 1, NULL);


--
-- TOC entry 4862 (class 0 OID 25396)
-- Dependencies: 218
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Role" ("Id", "Name") VALUES (1, 'Администратор');
INSERT INTO public."Role" ("Id", "Name") VALUES (2, 'Менеджер');
INSERT INTO public."Role" ("Id", "Name") VALUES (3, 'Клиент');


--
-- TOC entry 4866 (class 0 OID 25412)
-- Dependencies: 222
-- Data for Name: Status; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Status" ("Id", "Name") VALUES (1, 'Собирается');
INSERT INTO public."Status" ("Id", "Name") VALUES (2, 'В пути');
INSERT INTO public."Status" ("Id", "Name") VALUES (3, 'Доставлен');


--
-- TOC entry 4878 (class 0 OID 25456)
-- Dependencies: 234
-- Data for Name: Storage; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Storage" ("Id", "ProductId", "Count") VALUES (1, 1, 8.00);
INSERT INTO public."Storage" ("Id", "ProductId", "Count") VALUES (2, 2, 10.00);
INSERT INTO public."Storage" ("Id", "ProductId", "Count") VALUES (3, 3, 9.00);
INSERT INTO public."Storage" ("Id", "ProductId", "Count") VALUES (23, 23, 1.00);


--
-- TOC entry 4872 (class 0 OID 25433)
-- Dependencies: 228
-- Data for Name: Street; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Street" ("Id", "Name") VALUES (1, 'Бари Галеева');
INSERT INTO public."Street" ("Id", "Name") VALUES (2, 'Мира');
INSERT INTO public."Street" ("Id", "Name") VALUES (3, 'Победы');
INSERT INTO public."Street" ("Id", "Name") VALUES (4, 'Ершова');


--
-- TOC entry 4864 (class 0 OID 25403)
-- Dependencies: 220
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (1, 'Галеев', 'Рамазан', 'Рафаэлевич', NULL, 'Admin@gmail.com', '11', '+79393477261', 1, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (2, 'Габитов', 'Амир', 'Ирекович', 500.00, 'Manager@gmail.com', '1', '+78349249592', 2, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (3, 'Петров', 'Егор', 'Александрович', 60129.00, 'Egor@gmail.com', '1', '+79349205300', 3, 1, '3', NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (4, 'Габдрахманов', 'Рэдик', 'Флорисович', NULL, 'redikgabdr1@gmail.com', '1', '+79959461695', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (5, 'Смирнов', 'Дмитрий', 'Олегович', NULL, 'smirnov@mail.ru', 'password5', '+79165678901', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (6, 'Попова', 'Ольга', 'Викторовна', NULL, 'popova@mail.ru', 'password6', '+79166789012', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (7, 'Васильев', 'Сергей', 'Николаевич', NULL, 'vasilev@mail.ru', 'password7', '+79167890123', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (8, 'Новикова', 'Елена', 'Дмитриевна', NULL, 'novikova@mail.ru', 'password8', '+79168901234', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (9, 'Федоров', 'Андрей', 'Владимирович', NULL, 'fedorov@mail.ru', 'password9', '+79169012345', 3, NULL, NULL, NULL);
INSERT INTO public."User" ("Id", "Surname", "Name", "Patronymic", "Balance", "Email", "Password", "Phone", "RoleId", "StreetId", "House", "Apartment") VALUES (10, 'Морозова', 'Анна', 'Игоревна', NULL, 'morozova@mail.ru', 'password10', '+79160123456', 3, NULL, NULL, NULL);


--
-- TOC entry 4895 (class 0 OID 0)
-- Dependencies: 231
-- Name: Basket_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Basket_Id_seq"', 1, false);


--
-- TOC entry 4896 (class 0 OID 0)
-- Dependencies: 225
-- Name: CategoryProduct_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."CategoryProduct_Id_seq"', 1, false);


--
-- TOC entry 4897 (class 0 OID 0)
-- Dependencies: 223
-- Name: Order_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Order_Id_seq"', 1, false);


--
-- TOC entry 4898 (class 0 OID 0)
-- Dependencies: 229
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Product_Id_seq"', 1, false);


--
-- TOC entry 4899 (class 0 OID 0)
-- Dependencies: 217
-- Name: Role_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Role_Id_seq"', 1, false);


--
-- TOC entry 4900 (class 0 OID 0)
-- Dependencies: 221
-- Name: Status_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Status_Id_seq"', 1, false);


--
-- TOC entry 4901 (class 0 OID 0)
-- Dependencies: 233
-- Name: Storage_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Storage_Id_seq"', 1, false);


--
-- TOC entry 4902 (class 0 OID 0)
-- Dependencies: 227
-- Name: Street_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Street_Id_seq"', 1, false);


--
-- TOC entry 4903 (class 0 OID 0)
-- Dependencies: 219
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_Id_seq"', 2, true);


--
-- TOC entry 4705 (class 2606 OID 25454)
-- Name: Basket Basket_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Basket"
    ADD CONSTRAINT "Basket_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4699 (class 2606 OID 25431)
-- Name: CategoryProduct CategoryProduct_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CategoryProduct"
    ADD CONSTRAINT "CategoryProduct_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4697 (class 2606 OID 25424)
-- Name: Order Order_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "Order_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4703 (class 2606 OID 25447)
-- Name: Product Product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4691 (class 2606 OID 25401)
-- Name: Role Role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4695 (class 2606 OID 25417)
-- Name: Status Status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Status"
    ADD CONSTRAINT "Status_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4707 (class 2606 OID 25461)
-- Name: Storage Storage_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Storage"
    ADD CONSTRAINT "Storage_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4701 (class 2606 OID 25438)
-- Name: Street Street_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Street"
    ADD CONSTRAINT "Street_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4693 (class 2606 OID 25410)
-- Name: User User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4711 (class 2606 OID 25482)
-- Name: Product FK_Category; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "FK_Category" FOREIGN KEY ("CategoryId") REFERENCES public."CategoryProduct"("Id") NOT VALID;


--
-- TOC entry 4712 (class 2606 OID 25467)
-- Name: Basket FK_Product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Basket"
    ADD CONSTRAINT "FK_Product" FOREIGN KEY ("ProductId") REFERENCES public."Product"("Id") NOT VALID;


--
-- TOC entry 4715 (class 2606 OID 25487)
-- Name: Storage FK_Product_Storage; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Storage"
    ADD CONSTRAINT "FK_Product_Storage" FOREIGN KEY ("ProductId") REFERENCES public."Product"("Id") NOT VALID;


--
-- TOC entry 4708 (class 2606 OID 25492)
-- Name: User FK_Role; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "FK_Role" FOREIGN KEY ("RoleId") REFERENCES public."Role"("Id") NOT VALID;


--
-- TOC entry 4710 (class 2606 OID 25477)
-- Name: Order FK_Status; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Order"
    ADD CONSTRAINT "FK_Status" FOREIGN KEY ("StatusId") REFERENCES public."Status"("Id") NOT VALID;


--
-- TOC entry 4713 (class 2606 OID 25462)
-- Name: Basket FK_User; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Basket"
    ADD CONSTRAINT "FK_User" FOREIGN KEY ("UserId") REFERENCES public."User"("Id") NOT VALID;


--
-- TOC entry 4709 (class 2606 OID 25497)
-- Name: User FK_street; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "FK_street" FOREIGN KEY ("StreetId") REFERENCES public."Street"("Id") NOT VALID;


--
-- TOC entry 4714 (class 2606 OID 25472)
-- Name: Basket Fk_Order; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Basket"
    ADD CONSTRAINT "Fk_Order" FOREIGN KEY ("OrderId") REFERENCES public."Order"("Id") NOT VALID;


-- Completed on 2025-12-27 00:36:27

--
-- PostgreSQL database dump complete
--

