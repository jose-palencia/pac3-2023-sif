const cargarAutoresBtn = document.querySelector('#cargarAutores');
cargarAutoresBtn.addEventListener('click', obtenerDatos);

function obtenerDatos() {
   fetch('https://localhost:7112/api/autores')
   .then(respuesta => {
    return respuesta.json()
   })
   .then(resultado => {
       mostrarHTML(resultado);
       console.log(resultado);
   })
}

function mostrarHTML(datos) {
    const contenido = document.querySelector('#contenido');
    let html = `
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre de Autor</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
    `;

    datos.forEach(autor => {
        html += `
            <tr>
                <td>${autor.id}</td>
                <td>${autor.name}</td>
                <td>
                    <button onclick="editarAutor(${autor.id})">Editar</button>
                    <button onclick="borrarAutor(${autor.id})">Borrar</button>
                </td>
            </tr>
        `;
    });

    html += `
            </tbody>
        </table>
    `;

    contenido.innerHTML = html;
}

function editarAutor(id) {
    console.log(`Editando: ${id}`);
}

function borrarAutor(id) {
    console.log(`Borrando: ${id}`);
}