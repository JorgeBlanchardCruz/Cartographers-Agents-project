
/**
 * @author Jorge O. Blanchard Cruz
 * 
 */

"use strict";

//la dimensión 'y' ha sido bloqueada
var CAgent = function (Params, Tasks, Name, speed, Position, ActiveCollisions) {

    //STRUCTURES
    function path(name, path) {
        this._indx = 0;
        this._begin = false;
        this._name = name;        
        this._path = path.toString().split('');

        this.add_indx = function (Callback) {  //Recorre el vector de trayectoria
            if (!this._begin)
                return;

            if (this._indx < this._path.length - 1) {
                this._indx++;

                Callback("path");
            }
            else if (this._indx >= this._path.length - 1) {
                this.reset();
                Reactor();
            }
                 
        }

        this.get_CurrentMove = function () {
            return this._path[this._indx];
        }

        this.play = function () {
            this._begin = true;
        }

        this.stop = function () {
            this._begin = false;
        }

        this.reset = function () {
             this._begin = false;
             this._indx = 0;
         }
    }

    function sensor() {
        this._up      = 0;
        this._down    = 0;
        this._right   = 0;
        this._left    = 0;
        this._upperrightdiagonal = 0;
        this._upperleftdiagonal  = 0;
        this._lowerrightdiagonal = 0;
        this._lowerleftdiagonal  = 0;
    }
    

    //ATTRIBUTES
    const _MAXSWING = 0.03;
    const _SWINGSPEED = 0.001;
    const _SIZE = 0.3;
    const _BLOCKVISITED = 'v';
    const _BLOCKFREE = -1;
    const _BLOCKEXIT = 'e';
    const _MAXIMUNCHECKS = 10;

    var _Name = Name;
    var _Startpos = new position(Position.z, Position.x);
    var _Visualobj;  //objeto visual en el mundo 3d 

    //SWING
    var _countswing = 0;
    var _dirswing = false;

    //movement
    var _currentblock = _Startpos;
    var _distanceNewblock = 0;
    var _speed = Number(speed.toFixed(2));
    var _movement = 'stop';
    var _function = 'nothing';
    var _sensors = new sensor();
    
    var _direction = 0;

    //path
    var _Path = new path("null", "");
    
    //temp variable
    var obj_position;

    //INITIALIZE
    init();

    //PROCEDURES
    // Funciones matemáticas----------------------
    Math.degrees = function (radians) {
        return radians * 180 / Math.PI;
    };

    Math.radians = function (degrees) {
        return degrees * Math.PI / 180;
    };

    Math.floattoint = function (value) {
        return value | 0;
    };
    //////////////////////////////////////////////

    function init() {
        obj_position = document.getElementById('info1');

        Load_objmtl('meshes/WheatleyModel.obj', 'meshes/Ghost.mtl', _Startpos.x, 0, _Startpos.z, 0.08, 0.08, 0.08);   

        Params.MAPMatrix[_Startpos.z][_Startpos.x] = _BLOCKVISITED;
        Create_markerCalc(_Startpos.z, _Startpos.x);

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
                    object.name = "agent";

                    object.rotation.z = -Math.PI / 2;

                    _Visualobj = object;

                    Params.scene.add(_Visualobj);
                });
        }
        catch (err) { console.log(err); }
    }

    function Create_marker(z, x) {
        var object = new THREE.Mesh(new THREE.SphereGeometry(.15, 50, 50), new THREE.MeshBasicMaterial({ /*transparent: true, opacity: 0.7,*/ color: '#49A32A' }));
        object.name = "marker";
        object.position.set(x, 0, z);

        Params.scene.add(object);
    }

    function Create_markerCalc(z, x) {
        var object = new THREE.Mesh(new THREE.BoxGeometry(1, 1, 1), new THREE.MeshBasicMaterial({ transparent: true, opacity: 0.2, color: '#7938D9' }));
        object.name = "markerCalc";
        object.position.set(x, 0, z);

        Params.scene.add(object);
    }

    function SetBlockvisited() {
        _Visualobj.position.set(Number(_Visualobj.position.x.toFixed(0)), _Visualobj.position.y, Number(_Visualobj.position.z.toFixed(0)));
        if (Params.MAPMatrix[_Visualobj.position.z][_Visualobj.position.x] != _BLOCKVISITED) {
            Params.MAPMatrix[_Visualobj.position.z][_Visualobj.position.x] = _BLOCKVISITED;
            Create_markerCalc(_Visualobj.position.z, _Visualobj.position.x);
        }
    }

    function animate() {
        requestAnimationFrame(animate);

        if (_Visualobj != null)
            AccionAnimation();
    }

    function AccionAnimation() {

        if (_movement != undefined) {
            switch (_movement.toLowerCase()) {
                case 'w':
                    BlockbyBlock();
                    break;
                case 'a':
                case 'd':
                    _Visualobj.rotation.y = Math.radians(_direction);
                    _movement = 'stop';

                    _Path.add_indx(Move);
                    break;
                case 'obstacle':
                    SetBlockvisited();
                    Reactor();
                    break;
                default: //stop
                    _Visualobj.translateZ(0);
                    break;
            }
        }

        Swing();

        if (_function == "wait" && Tasks.length > 0) {
            //Si el agente está esperando, que ejecute su autonomia para comprobar si hay nuevas tareas.
            Reactor();
        }

        //obj_position.innerHTML = '<small> agent (z,x): ' + _Visualobj.position.z.toFixed(2).toString() + ' ; ' + _Visualobj.position.x.toFixed(2).toString() + '</small>';
    }

    function Swing() {
        //provoca una pequeña animación de arriba-abajo a Wheatley
        if (_countswing <= _MAXSWING) {
            _Visualobj.position.y += (_dirswing == false ? _SWINGSPEED : _SWINGSPEED * (-1));
            _countswing += _SWINGSPEED;
        }
        else {
            _dirswing = (_dirswing == false ? true : false);
            _countswing = 0
        }
    }

    function Move(movement) {
        _movement = movement;

        if (_movement == "path")
            _Path.play();
        else 
            _Path.stop();

        if (_Path._begin){
            _movement = _Path.get_CurrentMove();
            _distanceNewblock = 1;
        }
        else if (_movement == 'w')
            _distanceNewblock = 1;

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


    //  IA  ------------------------------------------------------------------------------
    function BlockbyBlock() {
        var newspeed = (_distanceNewblock < _speed ? _distanceNewblock : _speed);

        if (newspeed != 0) {
            var translate = (Borders_Delimeters() ? (ActiveCollisions ? (Collisions_perBLOCKS() ? newspeed : 0) : newspeed) : 0);
            _Visualobj.translateZ(translate);
            _distanceNewblock -= newspeed;
        }
        else {
            _movement = 'stop';

            SetBlockvisited();            
            _currentblock = new position(_Visualobj.position.z, _Visualobj.position.x);            

            _Visualobj.translateZ(0);

            _Path.add_indx(Move);
            //Create_marker(_Visualobj.position.z, _Visualobj.position.x);

            Autonomy();
        }

        return;
    }

    function Borders_Delimeters() {
        var possible = true;
        switch (_direction) { //según el movimiento Wheatley en el mapa
            case 0: //adelante
                if (_Visualobj.position.z >= Params.height - 1)
                    possible = false;
                break;
            case 90: //izquierda
                if (_Visualobj.position.x >= Params.width - 1)
                    possible = false;
                break;
            case 180: //atrás
                if (_Visualobj.position.z <= 0)
                    possible = false
                break;
            case 270: //derecha
                if (_Visualobj.position.x <= 0)
                    possible = false;
                break;
        }

        if (!possible) {
            _movement = 'stop'
            _Path.reset();
        }

        _movement = (possible == false ? 'stop' : _movement);
        return possible;
    }

    function Collisions() {
        //TODO ESTO HAY QUE OPTIMIZARLO, y MUCHO!
        //unificar los 4 bloques de código de colisión en una sola función dejaría dicha función con un montón de parámetros de entrada.
        //casi es mejor dejarlo así, tal vez sea más entendible, aunque complicado de modificar.

        for (var i = 0, l = Params.scene.children.length; i < l; i++) {
            if (Params.scene.children[i].name == Params.typesblocks[0]) { //Params.typesblocks.[0] = 'obstacle'
                var object = Params.scene.children[i];

                switch (_direction) { //según el movimiento Wheatley en el mapa
                    case 0: //abajo

                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Visualobj.position.z < object.position.z)) {

                            var distance = object.position.z - _Visualobj.position.z;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (object.position.z - (object.scale.z / 2)) - (_Visualobj.position.z + (_SIZE / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        } else if ((_Visualobj.position.z < object.position.z) && (_Visualobj.position.z - object.position.z < 1)) { //sentido correcto y objecto más cercano
                            var objwallmin = (object.position.x - (object.scale.x / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.x + (object.scale.x / 2)) + (_SIZE / 2);
                            if ((_Visualobj.position.x >= objwallmin) && ((_Visualobj.position.x) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((object.position.z - (object.scale.z / 2)) - (_Visualobj.position.z + (_SIZE / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        }

                        break;

                    case 180: //arriba

                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Visualobj.position.z > object.position.z)) {

                            var distance = _Visualobj.position.z - object.position.z;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (_Visualobj.position.z - (_SIZE / 2)) - (object.position.z + (object.scale.z / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        } else if ((_Visualobj.position.z > object.position.z) && (object.position.z - _Visualobj.position.z < 1)) { //sentido correcto y objecto más cercano
                            var objwallmin = (object.position.x - (object.scale.x / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.x + (object.scale.x / 2)) + (_SIZE / 2);
                            if ((_Visualobj.position.x >= objwallmin) && ((_Visualobj.position.x) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((_Visualobj.position.z - (_SIZE / 2)) - (object.position.z + (object.scale.z / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        }

                        break;

                    case 90: //izquierda

                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Visualobj.position.x < object.position.x)) {

                            var distance = object.position.x - _Visualobj.position.x;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (object.position.x - (object.scale.x / 2)) - (_Visualobj.position.x + (_SIZE / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        } else if ((_Visualobj.position.x < object.position.x) && (object.position.x - _Visualobj.position.x < 1)) { //sentido correcto y objecto más cercano
                            var objwallmin = (object.position.z - (object.scale.z / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.z + (object.scale.z / 2)) + (_SIZE / 2);
                            if ((_Visualobj.position.z >= objwallmin) && ((_Visualobj.position.z) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((object.position.x - (object.scale.x / 2)) - (_Visualobj.position.x + (_SIZE / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        }

                        break;

                    case 270: //derecha
                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Visualobj.position.x > object.position.x)) {

                            var distance = _Visualobj.position.x - object.position.x;
                            if (distance < 1) { //desechamos los lejanos
                                var distancetoObstacle = (_Visualobj.position.x - (_SIZE / 2)) - (object.position.x + (object.scale.x / 2));
                                if (distancetoObstacle <= 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
                                    return false;
                                }
                            }
                        } else if ((_Visualobj.position.x > object.position.x) && (_Visualobj.position.x - object.position.x < 1)) { //sentido correcto y objecto más cercano
                            var objwallmin = (object.position.z - (object.scale.z / 2)) - (_SIZE / 2);
                            var objwallMax = (object.position.z + (object.scale.z / 2)) + (_SIZE / 2);
                            if ((_Visualobj.position.z >= objwallmin) && ((_Visualobj.position.z) <= objwallMax)) {
                                var distancetoObstacle = Math.abs((_Visualobj.position.x - (_SIZE / 2)) - (object.position.x + (object.scale.x / 2)));
                                if (distancetoObstacle == 0.0) { //comprobamos la distancia del cercano
                                    //_movement = Params.typesblocks[0] + _direction;
                                    _movement = Params.typesblocks[0];

                                    _Path.reset();
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

    function Collisions_perBLOCKS() {
        //Igualmente, con la percepción del agente, no con los datos del mapa
        for (var i = 0, l = Params.scene.children.length; i < l; i++) {
            if (Params.scene.children[i].name == Params.typesblocks[0]) { //Params.typesblocks.[0] = 'obstacle'

                var object = Params.scene.children[i];
                switch (_direction) {
                    case 0: //abajo
                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Visualobj.position.z < object.position.z)) {
                            var distance = object.position.z - _Visualobj.position.z;
                            if (distance <= 1) {
                                //_movement = Params.typesblocks[0] + _direction;
                                _movement = Params.typesblocks[0];

                                _Path.reset();
                                return false;
                            }
                        }
                        break;
                    case 180: //arriba
                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.x.toFixed(0) == object.position.x.toFixed(0)) && (_Visualobj.position.z > object.position.z)) {
                            var distance = _Visualobj.position.z - object.position.z;
                            if (distance <= 1) {
                                //_movement = Params.typesblocks[0] + _direction;
                                _movement = Params.typesblocks[0];

                                _Path.reset();
                                return false;
                            }
                        }

                        break;
                    case 90: //izquierda
                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Visualobj.position.x < object.position.x)) {
                            var distance = object.position.x - _Visualobj.position.x;
                            if (distance <= 1) {
                                //_movement = Params.typesblocks[0] + _direction;
                                _movement = Params.typesblocks[0];

                                _Path.reset();
                                return false;
                            }
                        }
                        break;
                    case 270: //derecha
                        //mismo eje de movimiento y sentido correcto
                        if ((_Visualobj.position.z.toFixed(0) == object.position.z.toFixed(0)) && (_Visualobj.position.x > object.position.x)) {
                            var distance = _Visualobj.position.x - object.position.x;
                            if (distance <= 1) {
                                //_movement = Params.typesblocks[0] + _direction;
                                _movement = Params.typesblocks[0];

                                _Path.reset();
                                return false;
                            }
                        }
                        break;
                }
            }
        }

        return true;
    }

    function Searchstrategy_ASTAR(START, OBJETIVE, Mapcalculation) {

        function branch(nodes, value, heuristic) {
            this.nodes = nodes;
            this.value = Number(value);
            this.heuristic = Number(heuristic);

            this.SearchNode = function (nodesearch) {
                for (var i = 0; i < this.nodes.length; i++)
                    if (this.nodes[i].equal(nodesearch))
                        return i;

                return null;
            }

            this.CompareLastNode = function (nodesearch) {
                if (this.nodes[this.nodes.length - 1].equal(nodesearch))
                    return true

                return false;
            }

            this.clone = function () {
                return new branch(this.nodes.slice(0), this.value, this.heuristic);
            }

            this.get_StringPath = function () {

                if (this.nodes.length < 2) {
                    return "";
                }

                //determinar posicion inicial
                var stringpath = "";
                var anglestart = 0;
                var mov = "horizontal";

                if (this.nodes[0].x != this.nodes[1].x) { //movimiento horizontal
                    mov = "horizontal";
                    if (this.nodes[0].x > this.nodes[1].x) { //izquierda
                        stringpath = "dw";
                        anglestart = 270;
                    } else if (this.nodes[0].x < this.nodes[1].x) { //derecha
                        stringpath = "aw";
                        anglestart = 90;
                    }
                    
                } else if (_Startpos.z != this.nodes[1].z) { //movimiento vertical
                    mov = "vertical";
                    if (this.nodes[0].z > this.nodes[1].z) { //arriba
                        stringpath = "aaw";
                        anglestart = 180;
                    } else if (this.nodes[0].z < this.nodes[1].z) { //abajo
                        stringpath = "w"
                        anglestart = 0;
                    }             
                }
                //-----------------------------------
    
                var change = this.nodes[0].get_direction(this.nodes[1], anglestart);
                var prevchange = change;
                for (var i = 1; i < this.nodes.length - 1; i++) {
                    change = (this.nodes[i].get_direction(this.nodes[i + 1], prevchange));

                    var prev = this.nodes[i]
                    var current = this.nodes[i + 1];

                    if ((mov == "horizontal" && prev.z == current.z) || (mov == "vertical" && prev.x == current.x))
                        stringpath += "w";
                    else {
                        if (mov == "horizontal" && prev.z != current.z) {
                            mov = "vertical";

                            if (prevchange == 90) {
                                if (current.z > prev.z)
                                    stringpath += "dw";
                                else if (current.z < prev.z)
                                    stringpath += "aw";

                            } else if (prevchange == 270) {
                                if (current.z > prev.z)
                                    stringpath += "aw";
                                else if (current.z < prev.z)
                                    stringpath += "dw";
                            }
                        }
                        else if (mov == "vertical" && prev.x != current.x) {
                            mov = "horizontal";

                            if (prevchange == 180) {
                                if (current.x > prev.x)
                                    stringpath += "dw";
                                else if (current.x < prev.x)
                                    stringpath += "aw";

                            } else if (prevchange == 0) {
                                if (current.x > prev.x)
                                    stringpath += "aw";
                                else if (current.x < prev.x)
                                    stringpath += "dw";
                            }
                        }
                        var prevchange = change;
                    }
                }
                return stringpath;
            }
        }

        function next_calculation() {
            var count_newbranchs = 0;

            function AddCalculation(nbranch, z, x, type) {
                //if ((type == -1) || ((type >= 0 && type <= Params.typesblocks.length - 1) && (Params.blocks[type]._type != 'obstacle'))) {
                if (type == 'v' || ((OBJETIVE.z == z && OBJETIVE.x == x) && type == -1)) {

                    var newnode = new position(z, x);
                    nbranch.nodes.push(newnode);
                    nbranch.value += 1;
                    nbranch.heuristic = heuristic(newnode, OBJETIVE);

                    /* 2B3.Añadir las nuevas trayectorias a la lista ABIERTA, si existen. */
                    OPEN.push(nbranch);

                    if (Mapcalculation) {
                        Create_markerCalc(z, x); //crea un markador de calculo en el mapa
                    }

                    count_newbranchs++;
                }
            }

            //añadir las trayectorias posibles

            var NEWbranch = OPEN.shift(); //asigna y elimina la primera rama
            CLOSE.push(NEWbranch.clone());

            var z = Number(NEWbranch.nodes[NEWbranch.nodes.length - 1].z);
            var x = Number(NEWbranch.nodes[NEWbranch.nodes.length - 1].x);

            var newz;
            var newx;

            /*  2B2.Formar nuevas trayectorias a partir de la trayectoria eliminada de ABIERTA 
            ramificando el último nodo de la misma.  */
            //ramificar abajo
            newz = z + 1;            
            if (newz < Params.height) {
                var type = Params.MAPMatrix[newz][x];
                AddCalculation(NEWbranch.clone(), newz, x, type);
            }
                  
            //ramificar arriba
            newz = z - 1;             
            if (newz >= 0) {
                var type = Params.MAPMatrix[newz][x];
                AddCalculation(NEWbranch.clone(), newz, x, type);
            }


            //ramificar derecha
            newx = x + 1;
            if (newx < Params.width) {
                var type = Params.MAPMatrix[z][newx];
                AddCalculation(NEWbranch.clone(), z, newx, type);
            }
 
            //ramificar izquierda
            newx = x - 1;               
            if (newx >= 0) {
                var type = Params.MAPMatrix[z][newx];
                AddCalculation(NEWbranch.clone(), z, newx, type);
            }                        

            return count_newbranchs;
        }

        function bound(listA, listB, samelist) {

            for (var i = 0; i < listA.length; i++) {        
                var branchA = listA[i];
                var costA   = (branchA.value + branchA.heuristic);
     
                for (var j = 0; j < listB.length; j++) {
                    var branchB = listB[j];
                    var costB   = (branchB.value + branchB.heuristic);

                    //compara los dos últimos nodos de las listas A y B, y elimina de B la rama que sea de mayor coste
                    if ((branchA.nodes[branchA.nodes.length - 1].equal(branchB.nodes[branchB.nodes.length - 1]) == true) && (costA <= costB)) {
                        if ((!samelist) || (samelist && i != j)) {
                            listB.splice(j, 1);
                            j--;
                            i--;
                        }
                    }                        
                }
            }

        }

        function heuristic(node, objetive){
            return node.Manhattan_distance(objetive);
        }
        //--------------------------------------------

        /*  1. Formar una lista de trayectorias parciales, ABIERTA, con una trayectoria inicial
            que comienza en el nodo raíz. Formar una lista CERRADA, de trayectorias 
            desechadas mínimas, inicialmente vacía.     */
        var OPEN = new Array();
        OPEN.push(new branch(null, 0, heuristic(START, OBJETIVE)));
        OPEN[0].nodes = new Array();
        OPEN[0].nodes.push(START);

        var CLOSE = new Array();

        var i = 0;
        /*  2. Hasta que la lista ABIERTA esté vacía o se encuentre el objetivo, analizar su
        primera trayectoria: */
        /*  2A.Si la trayectoria termina en el nodo objetivo, se finaliza el bucle. */
        while (((OPEN.length != 0) && (!OPEN[0].CompareLastNode(OBJETIVE)))) {       
            /*  2B.Si la primera trayectoria no termina en el nodo objetivo:    */


            /*  2B1.Eliminar la primera trayectoria de la lista ABIERTA, incluyendola en la 
                lista CERRADA. En el caso de que ya exista una similar, eliminar la de
                mayor coste.                
                
                2B2.Formar nuevas trayectorias a partir de la trayectoria eliminada de ABIERTA 
                ramificando el último nodo de la misma.
                
                2B3.Añadir las nuevas trayectorias a la lista ABIERTA, si existen.   */
            var count_newbranchs = next_calculation();

            //  En el caso de que ya exista una similar, eliminar la de mayor coste.
            bound(OPEN, OPEN, true);

            /*  2B5. Si dos o más trayectorias de ABIERTA acaban en un nodo común, borrar las 
                mismas excepto la que posee mínimo coste entre ellas. Eliminar esta última
                también si existe una similar con menor coste en la lista CERRADA. Al 
                eliminar trayectorias de ABIERTA deben insertarse en CERRADA salvo que ya
                exista allí una similar de menor coste. */
            bound(CLOSE, OPEN, false);
            
            /*  2B4.Ordenar la lista ABIERTA en base al costo total estimado de cada una,
                colocando la de mínimo coste al inicio de la lista. */
            OPEN.sort(function (nodeA, nodeB) {
                return (nodeA.value + nodeA.heuristic) - (nodeB.value + nodeB.heuristic);
            });
            
            i++;
        }

        /*  3. Si se alcanza el nodo objetivo, el problema tiene solución y se determina la 
            trayectoria óptima, en caso contrario no existe solución. */
        if (OPEN.length != 0)
            return OPEN[0].get_StringPath();

        return "";
    }

    function Autonomy() {
        if (_function != 'autonomy')
            return;

        var movement = "stop";

        function UpdateSensors() {
            var z = _Visualobj.position.z;
            var x = _Visualobj.position.x;
            _sensors._up = (z > 0 ? Params.MAPMatrix[z - 1][x] : _BLOCKEXIT);
            _sensors._down = (z < Params.height - 1 ? Params.MAPMatrix[z + 1][x] : _BLOCKEXIT);
            _sensors._right = (x < Params.width - 1 ? Params.MAPMatrix[z][x + 1] : _BLOCKEXIT);
            _sensors._left = (x > 0 ? Params.MAPMatrix[z][x - 1] : _BLOCKEXIT);
            //_sensors._upperrightdiagonal = (z > 0 && x < Params.width - 1 ? Params.MAPMatrix[z - 1][x + 1] : _BLOCKEXIT);
            //_sensors._upperleftdiagonal = (z > 0 && x > 0 ? Params.MAPMatrix[z - 1][x - 1] : _BLOCKEXIT);
            //_sensors._lowerrightdiagonal = (z < Params.height - 1 && x < Params.width - 1 ? Params.MAPMatrix[z + 1][x + 1] : _BLOCKEXIT);
            //_sensors._lowerleftdiagonal = (z < Params.height - 1 && x > 0 ? Params.MAPMatrix[z + 1][x - 1] : _BLOCKEXIT);
        }

        function Decision() {

            function Remove(){

                function RemoveCube(z, x){
                    var id = Number('10' + Number(z) + '10' + Number(x));
                    var selectedObject = Params.scene.getObjectById(id);
                    Params.scene.remove(selectedObject);

                    Params.MAPMatrix[z][x] = _BLOCKFREE;

                    UpdateSensors();
                }

                if ((_sensors._up >= 0 && _sensors._up < Params.typesblocks.length) && Params.blocks[_sensors._up]._type == 'removable') {
                    RemoveCube(currentpos.z - 1, currentpos.x);
                }

                if ((_sensors._down >= 0 && _sensors._down < Params.typesblocks.length) && Params.blocks[_sensors._down]._type == 'removable') {
                    RemoveCube(currentpos.z + 1, currentpos.x);
                }

                if ((_sensors._right >= 0 && _sensors._right < Params.typesblocks.length) && Params.blocks[_sensors._right]._type == 'removable') {
                    RemoveCube(currentpos.z, currentpos.x + 1);
                }

                if ((_sensors._left >= 0 && _sensors._left < Params.typesblocks.length) && Params.blocks[_sensors._left]._type == 'removable') {
                    RemoveCube(currentpos.z, currentpos.x - 1);
                }                 
                return;
            }
            

            function CreateTasks(mov) {
                /*debe dejar tareas por hacer de los lugares que no visita,
                    sin contar por el que está apunto de abordar.
                */
                if (Up && mov != 'Up') {
                    Tasks.push(new task(new position(currentpos.z - 1, currentpos.x), _Name));
                }

                if (Down && mov != 'Down') {
                    Tasks.push(new task(new position(currentpos.z + 1, currentpos.x), _Name));
                }

                if (Right && mov != 'Right') {
                    Tasks.push(new task(new position(currentpos.z, currentpos.x + 1), _Name));
                }

                if (Left && mov != 'Left') {
                    Tasks.push(new task(new position(currentpos.z, currentpos.x - 1), _Name));
                }
            }
            
            var currentpos = new position(_Visualobj.position.z, _Visualobj.position.x);

            Remove();

            var Up = (_sensors._up == _BLOCKFREE ? 1 : 0);
            var Down = (_sensors._down == _BLOCKFREE ? 1 : 0);
            var Right = (_sensors._right == _BLOCKFREE ? 1 : 0);
            var Left = (_sensors._left == _BLOCKFREE ? 1 : 0);

            if (Up) { // siempre tenderá a ir hacia arriba
                CreateTasks('Up');

                _direction = 180;
                _Visualobj.rotation.y = Math.radians(_direction);
                movement = "w";
            }
            else if (Down) { //luego tenderá a ir abajo
                CreateTasks('Down');

                _direction = 0;
                _Visualobj.rotation.y = Math.radians(_direction);
                movement = "w";
            }
            else if (Right) {
                CreateTasks('Right');

                _direction = 90;
                _Visualobj.rotation.y = Math.radians(_direction);
                movement = "w";
            }
            else if (Left) {
                CreateTasks('Left');

                _direction = 270;
                _Visualobj.rotation.y = Math.radians(_direction);
                movement = "w";
            }
        }

        function TaskManager() {

            function Bound() {
                /* Sirve para eliminar todas las tareas por las que su posición ya se haya pasado.
                Tareas obsoletas.
                */
                for (var i = 0; i < Tasks.length; i++) {
                    var state = Params.MAPMatrix[Tasks[i]._position.z][Tasks[i]._position.x];
                    if (state == _BLOCKVISITED) {
                        Tasks.splice(i, 1);
                        i--;
                    }
                }
            }

            function Nearest_task() {

                function Discarded() {
                    var discard = false;
                    var j = 0;
                    while (!discard && j < DiscardTasks.length) {
                        if (DiscardTasks[j]._position.equal(Tasks[i]._position))
                            discard = true;

                        j++;
                    }

                    return discard;
                }

                if (Tasks.length <= 0)
                    return;

                var Distance = Start.Manhattan_distance(Tasks[0]._position);
                var min = 0;
                for (var i = 1; i < Tasks.length; i++) {
                    var newdistance = Start.Manhattan_distance(Tasks[i]._position);

                    if (!Discarded() && Distance > newdistance) {
                        Distance = newdistance;
                        min = i;
                    }
                }

                return min;
            }

            function ExecPath(stringpath){
                setPath("minimum_path", stringpath);

                _direction = 0;
                _Visualobj.rotation.y = Math.radians(_direction);
                    
                movement = "path";
            }

            if (movement != "stop") // no hay movimiento posible
                return;

            /*busca en las tareas. En caso de que exista tarea por realizar, 
            ejecutará A* para determinar la ruta mínima de los caminos visitados y llegar hasta la posición de la tarea.*/

            Bound(); //Eliminar tareas obsoletas.

            var DiscardTasks = new Array();
            var Start = new position(_Visualobj.position.z, _Visualobj.position.x);
            var Objetive;
            var iTask = -1; //se utiliza para obtener la tarea a realizar y en la nueva iteración, que no la tenga encuenta
            var chosen = false;
            var ichecks = 0;
            while (!chosen && Tasks.length > 0 && ichecks <= _MAXIMUNCHECKS) {

                ichecks++;

                if (Tasks.length > 0) { //si hay tareas pendientes
                    do { //recoge la posición más cercana que sea diferente de su posición actual

                        iTask = Nearest_task();
                        var maketask = Tasks[iTask];
                            
                        Objetive = new position(maketask._position.z, maketask._position.x);

                        if (Start.equal(Objetive))
                            Tasks.splice(iTask, 1);

                    } while (Start.equal(Objetive) && Tasks.length > 0);

                    if (Tasks.length <= 0)
                        Objetive = _Startpos;
                }
                else
                    Objetive = _Startpos;

                var stringpath = Searchstrategy_ASTAR(Start, Objetive, false); //Busca camino mínimo hasta la tarea
                if (stringpath != "") {//si existe el camino
                    Tasks.splice(iTask, 1); //ahora es cuando eliminamos la tarea pendiente.

                    ExecPath(stringpath);
                    _function = "path";

                    chosen = true;
                }
                else { //sino existe camino
                    //ponemos la tarea donde las desechadas para está vez.
                    DiscardTasks.push(Tasks[iTask]);

                    chosen = false;
                }
            }
      
            if ((!chosen && Tasks.length <= 0) || ichecks >= _MAXIMUNCHECKS) {
                Objetive = _Startpos;
                var stringpath = Searchstrategy_ASTAR(Start, Objetive, false);

                ExecPath(stringpath);

                if (ichecks >= _MAXIMUNCHECKS)
                    /*El agente ha hecho comprobaciones suficientes de camino 
                    como para identificar que no tiene nada más que hacer*/
                    _function = "finish";
                else
                    /*si ya se encuentra en su punto de partida y ha terminado todas las tareas
                    entra en estado de espera de tareas*/
                    _function = "wait";
            }

            return;
                
        }

        UpdateSensors();

        Decision();

        TaskManager();

        Move(movement);
    }
    //////////////////////////////////////////////////////////////////////////////////


    function setPath(name, agentpath) {
        _Path = new path(name, agentpath);
    }

    function Reactor() {
        _function = 'autonomy';
        Autonomy();
    }

    function Rev() {
        _Path.reset();
        _Visualobj.position.set(_Startpos.x, 0, _Startpos.z);
        _direction = 0;
        _Visualobj.rotation.y = _direction;
    }


    //METHODS
    this.setPath = function (name, agentpath) {
        setPath(name, agentpath);
    }

    this.Play = function () {
        Reactor();
    };

    this.ChangeSpeed = function (speed) {
        _speed = speed;
    }

    this.Pause = function () {
        _function = 'nothing';
        _movement = 'stop';
    };

    this.Rev = function () {
        Rev();
    }

    this.Move = function (accion) {
        Move(accion);
    };

};