1️⃣ Why minikube ip + NodePort sometimes fails

On Windows with Docker driver, your Kubernetes nodes run inside a Docker container, not a VM.

NodePorts (30080/30443) are exposed inside the Docker network, not directly to your host.

That’s why https://192.168.49.2:30443 doesn’t work — your host cannot reach the Docker network IP directly.

minikube service <service> --url works because Minikube opens a temporary proxy and forwards the traffic to the correct container.

But it only works while the terminal running Minikube is open.

2️⃣ How to reliably access your services from host on Windows
Option A — Keep using minikube service --url

Open a terminal and run:

minikube service clean-architecture-api-service --url


Use the ephemeral URL it prints (http://127.0.0.1:63742 or https://127.0.0.1:63743).

Keep the terminal open while accessing the service.

Option B — Use port-forwarding (works anytime)

Forward the pod/service port to your host:

kubectl port-forward service/clean-architecture-api-service 30080:80 30443:443


Then you can access:

http://127.0.0.1:30080/swagger/index.html
https://127.0.0.1:30443/swagger/index.html


This doesn’t require keeping minikube service open.

Option C — Use Ingress (recommended for multiple APIs)

Install Minikube’s ingress addon:

minikube addons enable ingress


Define an Ingress resource with hostnames for your APIs.

Then you can use friendly URLs like https://clean-architecture-api.local/swagger.

✅ Summary for your current setup on Windows Docker driver:

NodePort + Minikube IP won’t work directly.

You must either:

Use minikube service --url while terminal is open, or

Use kubectl port-forward to map ports to localhost.

If you want, I can write a step-by-step guide for both your APIs that uses port-forwarding so you can access HTTP and HTTPS without relying on Minikube ephemeral ports.