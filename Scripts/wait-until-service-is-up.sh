function service_status_code {
  echo $(curl -s -o /dev/null -w "%{http_code}" $host:$1/healthcheck)
}

function wait_service {
    res=$(service_status_code $2)
    until [[ "$res" == "200" ]]; do
      res=$(service_status_code $2)
      echo "$1 status: $res"
      sleep 3
    done
}

fakeSenderPort=5050

host="localhost"
if [ "$DOCKER_HOST" = '' ]; then
  host=$(docker-machine ip $DOCKER_MACHINE_NAME)
fi

# Wait services
wait_service "fake-sender" $fakeSenderPort

echo "I'm ready"
