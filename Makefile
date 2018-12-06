build:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		build ${ARGS}

start-dev:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		up --build

start-test:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		up --build -d

stop:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=fake-sender \
		-f docker-compose.yml \
		down
