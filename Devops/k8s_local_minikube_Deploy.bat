@echo off
echo ------------------------
echo Applying Secrets
echo ------------------------
kubectl apply -f aspnet-cert-secret.yaml
kubectl apply -f ghcr-secret.yaml

echo.
echo ------------------------
echo Creating ConfigMaps
echo ------------------------
kubectl create configmap vscode-api-settings --from-file=appsettings.json=.\AppSettings\K8s_Local_Minikube\Vscode-api\appsettings.mininkube.json --dry-run=client -o yaml | kubectl apply -f -


echo.
echo ------------------------
echo Deploying Pods and Services
echo ------------------------
kubectl apply -f clean-architecture-api.yaml
kubectl apply -f vscode-api.yaml

echo.
echo ------------------------
echo Done
echo ------------------------
pause