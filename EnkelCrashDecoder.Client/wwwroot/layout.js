
export class LayoutManager {

    static init() {

        window.componentInstances = {};

        var config = {
            content: [{
                type: 'row',
                content: [{
                    type: 'component',
                    componentName: 'testComponent',
                    componentState: { label: 'A' }
                }, {
                    type: 'column',
                    content: [{
                        type: 'component',
                        componentName: 'camera',
                        componentState: { label: 'B' }
                    }, {
                        type: 'component',
                        componentName: 'testComponent',
                        componentState: { label: 'C' }
                    }]
                }]
            }]
        };

        var buildComponent = function (container, componentState) {
            let uid = crypto.randomUUID();
            componentState.uid = uid;
            var futureObject = Blazor.rootComponents.add(container._contentElement[0], componentState.componentName, componentState);
            
            futureObject.then(component => {
                componentState.component = component;
                window.componentInstances[uid] = container;
            });
        };

        var gl = new GoldenLayout(config);

        gl.registerComponent('camera', buildComponent);

        gl.registerComponent('testComponent', function (container, componentState) {
            
        });

        window.gl = gl;

        gl.init();
    }
}
