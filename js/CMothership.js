
/**
 * @author Jorge O. Blanchard Cruz
 * 
 */
"use strict";

var CMothership = function (Params, AgentSpeed) {

    //STRUCTURES


    //ATTRIBUTES
    var _Tasks;
    var _Agents;

    //INITIALIZE
    init();

    //PROCEDURES
    function init() {
        _Tasks = new Array();
        _Agents = new Array()

        for (var i = 0; i < Params.PosAgents.length; i++) {
            _Agents.push(new CAgent(Params, _Tasks, i, AgentSpeed, Params.PosAgents[i], true));
            AgentSpeed += 0.02;
        }
    }

    //METHODS
    this.Play = function () {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Play();
        }    
    };

    this.ChangeSpeed = function (speed) {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].ChangeSpeed(speed);
        }
    };

    this.Pause = function (speed) {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Pause();
        }
    };

    this.Rev = function (speed) {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Rev();
        }
    };

    this.Move = function (accion) {
        _Agents[0].Move(accion);
    };   

};