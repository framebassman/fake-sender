build:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		build ${ARGS}

start:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		up --build

stop:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		down
