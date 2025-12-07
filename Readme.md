Comandi Git:
1) Creare un nuovo ramo partendo da un ramo presente in origin 
        git fetch origin <remote-branch>
        git checkout -b <local-branch> origin/<remote-branch>

Esempio, da origin/development per i nuovi sviluppi 
        git fetch origin development
        git checkout -b dev/task_724 origin/development


2) Aggiungere nuovi files (Prima del commit)
        git add .

3) Fare push di un ramo locale su un nuovo ramo remoto omonimo
        git push -u origin <branch>
        git push -u  origin dev/task_724



Minikube (Kubernetes)
https://minikube.sigs.k8s.io/docs/start/?arch=%2Fwindows%2Fx86-64%2Fstable%2F.exe+download

minikube status ==> Vede lo stato di minikube
minikube start ==> Fa partire minikube
kubectl get pods
kubectl get services
kubectl logs clean-architecture-api-7d76f48f9d-8wdmm 
kubectl apply -f ...
minikube ip

*************Esporre il servizio*****************************
minikube service vscode-api-service --url   (Proxy da kubectl (hostato in docker) alle porte locali del PC. le porte vengono assegnate in modo randomico)
oppure 
kubectl port-forward service/clean-architecture-api-service 30080:80 30443:443
oppure
minikube addons enable ingress
kubectl delete service clean-architecture-api-service

minikube start -p multi-node-k8s --nodes=3 --driver=docker --container-runtime=containerd extra-config=kubeadm.node-name=minikube wait=all

kubectl get nodes -l role=worker

kubectl label nodes multi-node-k8s-m03 role=worker
Poweshell
[Convert]::ToBase64String((Get-Content -Path "C:\Users\gianl\.dotnet\https\aspnetapp.pfx" -Encoding Byte)) > aspnetapp.b64
