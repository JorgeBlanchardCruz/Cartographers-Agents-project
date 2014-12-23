
/**
 * @author Jorge O. Blanchard Cruz
 * 
 */
"use strict";

var CMothership = function (Params, MarkVisited, InverseMap) {

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

        var AgentSpeed = 0.1;
        var Maxswing = 0.03;
        for (var i = 0; i < Params.PosAgents.length; i++) {
            _Agents.push(new CAgent(Params, _Tasks, i, AgentSpeed, Params.PosAgents[i], true, Maxswing, MarkVisited, InverseMap));
            AgentSpeed += 0.01;
            Maxswing += 0.005;
        }
    }

    //METHODS
    this.Play = function () {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Play();
            AgentSpeed += 0.02;
        }    
    };

    this.ChangeSpeed = function () {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].ChangeSpeed(_Agents[i].get_speed() + 0.02);
        }
    };

    this.Pause = function (speed) {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Pause();
        }
    };

    this.Rev = function () {
        for (var i = 0; i < _Agents.length; i++) {
            _Agents[i].Rev();
        }

        _Agents[0].Clear_BlockVisits();
    };

    this.Move = function (accion) {
        _Agents[0].Move(accion);
    };   

};