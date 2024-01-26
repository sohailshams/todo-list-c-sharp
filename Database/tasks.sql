CREATE TABLE public.tasks (
	id int NOT NULL GENERATED ALWAYS AS IDENTITY,
	title varchar NOT NULL,
	description varchar NOT NULL
);
