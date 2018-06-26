docker build --file ./Dockerfile .
echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker push framebassman/fake-sender