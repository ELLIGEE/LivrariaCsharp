CREATE TABLE public."Autor" (
	id int4 NOT NULL,
	"Nome" varchar NOT NULL,
	"Nacionalidade" varchar NOT NULL,
	CONSTRAINT autor_id PRIMARY KEY (id)
);

CREATE TABLE public."Livro" (
	id int4 NOT NULL,
	"Titulo" varchar NOT NULL,
	ano_publicacao int4 NOT NULL,
	CONSTRAINT livro_id PRIMARY KEY (id)
);

CREATE TABLE public."LivroAutor" (
	"AutorId" int4 NULL,
	"LivroId" int4 NULL,
	CONSTRAINT "livro_autor_autor_FK" FOREIGN KEY ("AutorId") REFERENCES public."Autor"(id),
	CONSTRAINT "livro_autor_livro_FK" FOREIGN KEY ("LivroId") REFERENCES public."Livro"(id)
);