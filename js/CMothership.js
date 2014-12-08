
/**
 * @author Jorge O. Blanchard Cruz
 * 
 */
"use strict";

var CMothership = function (Params, AgentSpeed) {

    //STRUCTURES


    //ATTRIBUTES
    var _Tasks;
    var _Agent;

    //INITIALIZE
    init();

    //PROCEDURES
    function init() {
        _Tasks = new Array();

        _Agent = new CAgent(Params, _Tasks, AgentSpeed, true);
    }

    //METHODS
    this.Agent = function () {
        return _Agent
    };
   

};