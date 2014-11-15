
/**
 * @author Jorge O. Blanchard Cruz
 * 
 */

//la dimensi�n 'y' ha sido bloqueada
var CAgent = function (Params, speed, ActiveCollisions, z, x) {
    "use strict";

    //ATTRIBUTES
    const _MAXSWING = 0.03;
    const _SWINGSPEED = 0.001;
    const _SIZE = 0.3;

    var _Wheatley;  //objeto visual en el mundo 3d  
    ///Para la trayectoria
    var bloque = 0;         //Variable para mover de bloque en bloque
    var trayectoria = ['w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'd', 'w', 'w', 'w', 'a', 'w', 'w', 'w', 'w', 'w', 'w', 'w']; //Trayectoria a seguir,esta resuelve el camino del mapa de prueba
    var iniciar = false;
    var indx = 0;   //Indice para recorrer la trayectoria
    //SWING
    var _countswing = 0;
    var _dirswing = false;

    //movement
    var _speed = speed;
    var _movement = 'stop';
    
    var _direction = 0;
    
    //temp variable
    var camera_position;

    //INITIALIZE
    init();

    //PROCEDURES
    // Converts from radians to degrees.
    Math.degrees = function (radians) {
        return radians * 180 / Math.PI;
    };

    Math.radians = function (degrees) {
        return degrees * Math.PI / 180;
    };

    function init() {
        camera_position = document.getElementById('camera_position');
        Load_objmtl('meshes/WheatleyModel.obj', 'meshes/Ghost.mtl', x, 0, z, 0.08, 0.08, 0.08);

        animate();
    }
    
    function Load_objmtl(fileobj, filemtl, x, y, z, scalex, scaley, scalez) {
        try {
            THREE.Loader.Handlers.add(/\.dds$/i, new THREE.DDSLoader());
            var loader = new THREE.OBJMTLLoader();
            loader.load(fileobj, filemtl,
                function (object) {
                    object.position.set(x, y, z);
                    object.scale.set(scalex, scaley, scalez);
                    object.castShadow = true;
                    object.receiveShadow = true;

                    object.rotation.z = -Math.PI / 2;
                    //object.rotation.y = Math.PI / 2;

                    _Wheatley = object;

                    Params.scene.add(_Wheatley);
                });
        }
        catch (err) { console.log(err); }
    }

   /* function Move(movement) {
        _movement = movement;

        var rotate = 0;
        switch (_movement) {
            case 'a':
                rotate = Math.degrees(Math.PI / 2);
                break;
            case 'd':
                rotate = Math.degrees(Math.PI / 2) * (-1);
                break;
            default: 
                break;
        }

        Calculate_direction(rotate);

        function Calculate_direction(rotate) {
            _direction += rotate;
            _direction = (_direction == -90 ? 270 : _direction);
            _direction = (_direction >= 360 ? 0 : _direction);       
        }
    }

    function AccionAnimation() {
        switch (_movement) {
            case 'w':      
                _Wheatley.translateZ((Borders_Delimeters() ? (ActiveCollisions ? (Collisions() ? _speed : 0) : _speed) : 0));
                break;
            case 'a':
            case 'd':
                _Wheatley.rotation.y = Math.radians(_direction);
                _movement = 'stop';
                break;
            default: //stop
                _Wheatley.translateZ(0);
                break;
        }

        Swing();
        
        //camera_position.innerHTML = 'obj position: ' + _Wheatley.position.x.toFixed(2).toString() + ';' + _Wheatley.position.y.toFixed(2).toString() + ';' + _Wheatley.position.z.toFixed(2).toString();
        camera_position.innerHTML = 'Wheatley pos(z,x): ' + _Wheatley.position.z.toFixed(2).toString() + ' ; ' + _Wheatley.position.x.toFixed(2).toString();
    }
    */
    function Move(movement) {
        if (movement == 'i') {  //Pulsar i para iniciar el recorrido, se puede cambiar por un boton o algo, esto es solo para probar
            iniciar = true;
            _movement = 'stop';
        }


        if (iniciar) {
            _movement = trayectoria[indx];
            var rotate = 0;
            switch (_movement) {
                case 'a':
                    rotate = Math.degrees(Math.PI / 2);
                    break;
                case 'd':
                    rotate = Math.degrees(Math.PI / 2) * (-1);
                    break;
                default:
                    break;
            }

            Calculate_direction(rotate);

        }

        function Calculate_direction(rotate) {
            _direction += rotate;
            _direction = (_direction == -90 ? 270 : _direction);
            _direction = (_direction >= 360 ? 0 : _direction);
        }
    }
    function AccionAnimation() {
        switch (_movement) {
            case 'w':
                // _Wheatley.translateZ((Borders_Delimeters() ? (Collisions() ? _speed : 0) : 0));
                MoverUnBloque();    //Mueve un bloque completo 
                break;
            case 'a':
            case 'd':
                _Wheatley.rotation.y = Math.radians(_direction);
                _movement = 'stop';
                add_indx(); //Suma uno al indicie para seguir con el siguiente movimiento
                break;
            default: //stop
                _Wheatley.translateZ(0);
                break;
        }

        Swing();

        //camera_position.innerHTML = 'obj position: ' + _Wheatley.position.x.toFixed(2).toString() + ';' + _Wheatley.position.y.toFixed(2).toString() + ';' + _Wheatley.position.z.toFixed(2).toString();
        camera_position.innerHTML = 'Wheatley pos(z,x): ' + _Wheatley.position.z.toFixed(2).toString() + ' ; ' + _Wheatley.position.x.toFixed(2).toString();
    }
    function MoverUnBloque() {
        if (bloque < 1) {
            _Wheatley.translateZ((Borders_Delimeters() ? (Collisions() ? _speed : 0) : 0));
            bloque += _speed;
        }
        else {
            bloque = 0;
            _movement = 'stop';
            _Wheatley.translateZ(0);
            add_indx();
        }
    }
    function add_indx() {   //Recorre el vector de trayectoria
        if (indx < trayectoria.length - 1) {
            indx++;
            Move('i');
        }
    }
    function Borders_Delimeters() {
        var possible = true;
        switch (_direction) { //seg�n el movimiento Wheatley en el mapa
            case 0: //adelante
                if (_Wheatley.position.z >= Params.height - 1)
                    possible = false;
                break;
            case 90: //izquierda
                if (_Wheatley.position.x >= Params.width - 1)
                    possible = false;
                break;
            case 180: //atr�s
                if (_Wheatley.position.z <= 0)
                    possible = false
                break;
            case 270: //derecha
                if (_Wheatley.position.x <= 0)
                    possible = false;
                break;
        }
        _movement = (possible == false ? 'stop' : _movement);
        return possible;
    }

    function Collisions() {
        const TOLERANCE = -0.01;

        //TODO ESTO HAY QUE OPTIMIZARLO, y MUCHO!
        //unificar los 4 bloques de c�digo de colisi�n en una sola funci�n dejar�a dicha funci�n con un mont�n de par�metros de entrada.
        //casi es mejor dejarlo as�, tal vez sea m�s entendible, aunque complicado de modificar.

        for (var i = 0, l = Params.scene.children.length; i < l; i++) {            
            var object = Params.scene.children[i];
            if (object.name == 'obstacle') {
                switch (_direction) { //seg�n el movimiento Wheatley en el mapa
                    case 0: //adelante

                        //mismo eje de movimiento y sentido correcto
                        if ((_Wheatley.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Wheatley.position.z < object.position.z)) {

                            var distance = object.position.z - _Wheatley.position.z; 
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (object.position.z - (object.scale.z / 2)) - (_Wheatley.position.z + (_SIZE / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 0';
                                    return false;
                                }
                            }
                        } else if ((_Wheatley.position.z < object.position.z) && (_Wheatley.position.z - object.position.z < 1)) { //sentido correcto y objecto m�s cercano
                            var objwallmin = (object.position.x - (object.scale.x / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.x + (object.scale.x / 2)) + (_SIZE / 2);
                            if ((_Wheatley.position.x >= objwallmin) && ((_Wheatley.position.x) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((object.position.z - (object.scale.z / 2)) - (_Wheatley.position.z + (_SIZE / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 180';
                                    return false;
                                }
                            }
                        }

                        break;

                    case 180: //atr�s

                        //mismo eje de movimiento y sentido correcto
                        if ((_Wheatley.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Wheatley.position.z > object.position.z)) {

                            var distance = _Wheatley.position.z - object.position.z;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (_Wheatley.position.z - (_SIZE / 2)) - (object.position.z + (object.scale.z / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 180';
                                    return false;
                                }
                            }
                        } else if ((_Wheatley.position.z > object.position.z) && (object.position.z - _Wheatley.position.z < 1)) { //sentido correcto y objecto m�s cercano
                            var objwallmin = (object.position.x - (object.scale.x / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.x + (object.scale.x / 2)) + (_SIZE / 2);
                            if ((_Wheatley.position.x >= objwallmin) && ((_Wheatley.position.x) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((_Wheatley.position.z - (_SIZE / 2)) - (object.position.z + (object.scale.z / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 180';
                                    return false;
                                }
                            }
                        }

                        break;

                    case 90: //izquierda

                        //mismo eje de movimiento y sentido correcto
                        if ((_Wheatley.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Wheatley.position.x < object.position.x)) {

                            var distance = object.position.x - _Wheatley.position.x;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (object.position.x - (object.scale.x / 2)) - (_Wheatley.position.x + (_SIZE / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 90';
                                    return false;
                                }
                            }
                        } else if ((_Wheatley.position.x < object.position.x) && (object.position.x - _Wheatley.position.x < 1)) { //sentido correcto y objecto m�s cercano
                            var objwallmin = (object.position.z - (object.scale.z / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.z + (object.scale.z / 2)) + (_SIZE / 2);
                            if ((_Wheatley.position.z >= objwallmin) && ((_Wheatley.position.z) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((object.position.x - (object.scale.x / 2)) - (_Wheatley.position.x + (_SIZE / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 90';
                                    return false;
                                }
                            }
                        }

                        break;

                    case 270: //derecha
                        //mismo eje de movimiento y sentido correcto
                        if ((_Wheatley.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Wheatley.position.x > object.position.x)) {

                            var distance = _Wheatley.position.x - object.position.x;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (_Wheatley.position.x - (_SIZE / 2)) - (object.position.x + (object.scale.x / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 270';
                                    return false;
                                }
                            }
                        } else if ((_Wheatley.position.x > object.position.x) && (_Wheatley.position.x - object.position.x < 1)) { //sentido correcto y objecto m�s cercano
                            var objwallmin = (object.position.z - (object.scale.z / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.z + (object.scale.z / 2)) + (_SIZE / 2);
                            if ((_Wheatley.position.z >= objwallmin) && ((_Wheatley.position.z) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((_Wheatley.position.x - (_SIZE / 2)) - (object.position.x + (object.scale.x / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    _movement = 'obstacle 90';
                                    return false;
                                }
                            }
                        }
                        break;
                }
            }
        }
        return true;
    }

    function Swing() {
        //provoca una peque�a animaci�n de arriba-abajo a Wheatley
        if (_countswing <= _MAXSWING) {
            _Wheatley.position.y += (_dirswing == false ? _SWINGSPEED : _SWINGSPEED * (-1));
            _countswing += _SWINGSPEED;
        }
        else {
            _dirswing = (_dirswing == false ? true : false);
            _countswing = 0
        }
    }

    function animate() {
        requestAnimationFrame(animate);

        if (_Wheatley != null) AccionAnimation();

        render();
    }

    function render() {
        Params.renderer.render(Params.scene, Params.camera);
    }

    //METHODS
    this.Move = function (movement) { Move(movement); };

};