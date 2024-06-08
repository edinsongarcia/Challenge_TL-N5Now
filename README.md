
# Challenge técnico TL Backend





## Pasos para ejecutar el proyecto

 1. Tener en ejecución docker desktop
 2. Ejecutar el siguiente comando en la raiz del proyecto ejemplo:


```bash
  PS C:\Users\USUARIO\Documents\N5\ChallengeN5Now> docker compose build
```
 3. Ejecutar docker
 ```bash
  PS C:\Users\USUARIO\Documents\N5\ChallengeN5Now> docker compose up
```
4. Monitorear que las imagenes y contenedores esten ejecutandose correctamente.

Nota: la imagen de challengen5nowapi en ocaciones puede presentar error de conexion con la base de datos, se sugiere ejecutar nuevamente desde la interfaz de docker desktop para lograr que el api se conecte correctamente.

5. Si la imagen de challengen5nowapi se ejecuto de manera correcta se debe de abrir la siguiente URL http://localhost:5001/swagger/index.html para poder interactuar con las APIs.
    
## Checklist de requisitos del challenge

  - El web api debe tener 3 servicios “Request Permission”, “Modify Permission” y “Get Permissions” Cada servicio debe conservar un registro de permisos en un índice de elasticsearch, el registro insertado en Elasticsearch debe contener la misma estructura de la tabla de base de datos "Permission"✅ 
- Cree apache kafka en el entorno local y cree un nuevo tema donde  Persistir cada operación un mensaje con la siguiente estructura DTO(id Random Guid, Name operation)✅
- Hacer uso del patrón de repositorio y la unidad de trabajo y CQRS patrón✅
- Tener en cuenta que es necesario ceñirse a un arquitectura de servicios para que la creación de diferentes capas y inyección de dependencias✅
- Agregar en los logs en cada punto de conexión de la API y registre el nombre de Operación utilizando serilog como biblioteca de registros.✅
- Cree pruebas unitarias y pruebas de integración para llamar a los tres servicios ⚠️
- Usar buenas practicas ✅
- Preparación de la solución que se va a incluir en contenedores en una imagen de Docker✅
- Preparar la solución que se va a implementar en Kubernetes⚠️
